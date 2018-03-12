using LocationParser.Current;
using LocationParser.Extensions.Models;
using LocationParser.Models.Google;
using ConsoleAppBase.Attributes;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using LocationParser.Data.External;

namespace LocationParser.Commands.FileIO
{
	[Command(Name = "read", Description = "Read a new Location history file")]
	class ReadCommand : MainCommand
	{
		[CommandArgument(1, Name = "path", Description = "The path of the JSON file with the locations.", Required = true)]
		public string TimeLinePath { get; set; }

		[CommandOption(Template = "-m|--multiple", Description = "Flag to read all files in a given directory.")]
		public bool MultipleFiles { get; set; }

		[CommandOption(Template = "-z|--zipped", Description = "Flag to read zipped timelines.")]
		public bool Zipped { get; set; }

		public override int OnExecute()
		{
			if (!ValidPath())
			{
				ShowHelp();
			}

			var mergedTimeLine = FileInteraction.GetTimeLinesFrom(TimeLinePath, MultipleFiles, Zipped);

			CurrentFile.Write(mergedTimeLine);
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
	}
}
