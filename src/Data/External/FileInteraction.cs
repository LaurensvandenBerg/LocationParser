using LocationParser.Extensions.Models;
using LocationParser.Models.Google;
using LocationParser.Models.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace LocationParser.Data.External
{
	class FileInteraction
	{
		internal static TimeLine GetTimeLinesFrom(string path, bool multiple, bool zipped)
		{
			var timeLinePaths = GetTimeLines(path, multiple, zipped);

			var mergedTimeLine = new TimeLine()
			{
				timeEntries = timeLinePaths
					.SelectMany(p => JsonConvert.DeserializeObject<Locations>(File.ReadAllText(p))
						.ToTimeLine()
						.timeEntries)
			};
			//CleanupZipFiles(path);
			return mergedTimeLine;
		}

		internal static IEnumerable<string> GetTimeLines(string path, bool multiple, bool zipped)
		{
			var paths = new[] { path };
			if (zipped)
			{
				UnzipAllTimeLines(path);
			}
			if (multiple)
			{
				paths = Directory.GetFiles(path, "*.json");
			}
			return paths;
		}

		private static void UnzipAllTimeLines(string path)
		{
			var zipFiles = Directory.GetFiles(path, "*.zip").ToList();
			var extractionPaths = Enumerable.Range(0, zipFiles.Count).Select(i => Path.Combine(path, "ExtractedTimeLines") + i).ToList();

			for (int i = 0; i < zipFiles.Count(); i++)
			{
				ZipFile.ExtractToDirectory(zipFiles.ElementAt(i), extractionPaths.ElementAt(i));
			}

			for (int i = 0; i < zipFiles.Count(); i++)
			{
				var sourcePath = Path.Combine(extractionPaths.ElementAt(i), GetLanguage(extractionPaths.ElementAt(i)));
				var destinationPath = Path.Combine(path, "Hist" + i + ".json");
				File.Move(sourcePath, destinationPath);
			}

			extractionPaths.ForEach(p => Directory.Delete(p, true));
		}

		private static string GetLanguage(string path)
		{
			if (File.Exists(Path.Combine(path, "Takeout/Location History/Location History.json")))
			{
				return "Takeout/Location History/Location History.json";
			}
			if (File.Exists(Path.Combine(path, "Takeout/Locatiegeschiedenis/Locatiegeschiedenis.json")))
			{
				return "Takeout/Locatiegeschiedenis/Locatiegeschiedenis.json";
			}
			return "pathnotfound";
		}

		private static void CleanupZipFiles(string path)
		{
			var paths = Directory.GetFiles(path, "Hist*.json").ToList();
			paths.ForEach(p => File.Delete(p));
		}
	}
}
