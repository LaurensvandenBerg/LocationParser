using LocationParser.Models.Internal;
using Newtonsoft.Json;
using System;
using System.IO;

namespace LocationParser.Current
{
	public static class CurrentFile
	{
		private static readonly DirectoryInfo filePath = !Directory.Exists(@"Current") ? Directory.CreateDirectory(@"Current") : new DirectoryInfo(@"Current");
		private static string currentTimeLine = "\\currentTimeLine.json";

		public static TimeLine Read()
		{
			if (!Exists())
			{
				Console.WriteLine("There is no timeline in the current working directory");
				return new TimeLine();
			}
			return JsonConvert.DeserializeObject<TimeLine>(File.ReadAllText(@"Current\currentTimeLine.json"));
		}

		public static void Write(TimeLine timeLine) => File.WriteAllText(@"Current\currentTimeLine.json", JsonConvert.SerializeObject(timeLine));

		private static bool Exists() => File.Exists(filePath + currentTimeLine);
	}
}
