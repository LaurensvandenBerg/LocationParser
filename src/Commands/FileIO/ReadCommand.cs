using LocationParser.Current;
using LocationParser.Extensions.Models;
using LocationParser.Models.Google;
using ConsoleAppBase.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace LocationParser.Commands.FileIO
{
	[Command(Name = "read", Description = "Read a new Location history file")]
	class ReadCommand : MainCommand
	{
		[CommandArgument(1, Name = "path", Description = "The path of the JSON file with the locations.", Required = true)]
		public string TimeLinePath { get; set; }

		[CommandOption(Template = "-m|--multiple", Description = "flag to read all files in a given directory")]
		public bool MultipleFiles { get; set; }

		[CommandOption(Template = "-z|--zipped")]
		public bool Zipped { get; set; }

		public override int OnExecute()
		{
			if (!ValidPath())
			{
				ShowHelp();
			}
			var timeLinePaths = GetTimeLines();

			var mergedTimeLine = new Models.Internal.TimeLine()
			{
				timeEntries = timeLinePaths
					.SelectMany(p => JsonConvert.DeserializeObject<Locations>(File.ReadAllText(p))
						.ToTimeLine()
						.timeEntries)
			};
			CurrentFile.Write(mergedTimeLine);

			CleanupZipFiles();
			return 0;
		}

		private bool ValidPath()
		{
			if (MultipleFiles)
			{
				return Directory.Exists(TimeLinePath);
			}
			return File.Exists(TimeLinePath);
		}

		private IEnumerable<string> GetTimeLines()
		{
			var paths = new[] { TimeLinePath };
			if (Zipped)
			{
				UnzipAllTimeLines();
			}
			if (MultipleFiles)
			{
				paths = Directory.GetFiles(TimeLinePath, "*.json");
			}
			return paths;
		}

		private void UnzipAllTimeLines()
		{
			var zipFiles = Directory.GetFiles(TimeLinePath, "*.zip").ToList();
			var extractionPaths = Enumerable.Range(0, zipFiles.Count).Select(i => Path.Combine(TimeLinePath, "ExtractedTimeLines") + i).ToList();
			
			for(int i = 0; i < zipFiles.Count(); i++)
			{
				ZipFile.ExtractToDirectory(zipFiles.ElementAt(i), extractionPaths.ElementAt(i));
			}

			for(int i = 0; i < zipFiles.Count(); i++)
			{
				var sourcePath = Path.Combine(extractionPaths.ElementAt(i), GetLanguage(extractionPaths.ElementAt(i)));
				var destinationPath = Path.Combine(TimeLinePath, "Hist" + i + ".json");
				File.Move(sourcePath, destinationPath);
			}
			
			extractionPaths.ForEach(p => Directory.Delete(p, true));
		}

		private void CleanupZipFiles()
		{
			var paths = Directory.GetFiles(TimeLinePath, "Hist*.json").ToList();
			paths.ForEach(p => File.Delete(p));
		}

		private string GetLanguage(string path)
		{
			if (File.Exists(Path.Combine(path, "Takeout/Location History/Location History.json")))
			{
				return "Takeout/Location History/Location History.json";
			}
			if(File.Exists(Path.Combine(path, "Takeout/Locatiegeschiedenis/Locatiegeschiedenis.json")))
			{
				return "Takeout/Locatiegeschiedenis/Locatiegeschiedenis.json";
			}
			return "pathnotfound";
		}
		
	}
}
