using LocationParser.Data;
using ConsoleAppBase;
using System.IO;

namespace LocationParser.Commands.FileIO
{
	[Command("save", Description = "Save the current working TimeLine to with a specified name")]
	class SaveCommand : MainCommand
	{
		[CommandArgument(2, Name = "name", Description = "The name of the TimeLine", Required = true)]
		public string TimeLineName { get; set; }

		[CommandArgument(2, Name = "path", Description = "optional path of the TimeLine", Required = false)]
		public string Path { get; set; }

		public override int OnExecute()
		{
			var store = new FileStore();
			if (string.IsNullOrWhiteSpace(Path))
			{
				store.Store(TimeLineName);
			}
			else
			{
				var newPath = Directory.Exists(Path) ? new DirectoryInfo(Path) : Directory.CreateDirectory(Path);
				store.Store(TimeLineName, newPath);
			}
			return 0;
		}
	}
}
