using LocationParser.Current;
using LocationParser.Extensions.Models;
using LocationParser.Models.Google;
using ConsoleAppBase;
using Newtonsoft.Json;
using System.IO;

namespace LocationParser.Commands.FileIO
{
	[Command("read", Description = "Read a new Location history file")]
	class ReadCommand : MainCommand
	{
		[CommandArgument(1, Name = "path", Description = "The path of the JSON file with the locations.", Required = true)]
		public string Path { get; set; }

		public override int OnExecute()
		{
			if (!File.Exists(Path))
			{
				throw new FileNotFoundException($"File at location: '{Path}' not found.");
			}
			CurrentFile.Write(JsonConvert.DeserializeObject<Locations>(File.ReadAllText(Path)).ToTimeLine());
			return 0;
		}
	}
}
