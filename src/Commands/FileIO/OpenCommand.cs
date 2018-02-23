using LocationParser.Data;
using ConsoleAppBase.Attributes;
using System;

namespace LocationParser.Commands.FileIO
{
	[Command(Name = "open", Description = "Open a previously saved Timeline")]
	class OpenCommand : MainCommand
	{
		[CommandArgument(1, Name = "name", Description = "The name of the Timeline to be opened", Required = false)]
		public string TimeLineName { get; set; }

		public override int OnExecute()
		{
			var store = new FileStore();
			if (string.IsNullOrWhiteSpace(TimeLineName))
			{
				Console.WriteLine(string.Join("\n", store.List()));
				return 0;
			}
			store.Load(TimeLineName);
			return 0;
		}
	}
}
