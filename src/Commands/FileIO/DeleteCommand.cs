using LocationParser.Data;
using ConsoleAppBase.Attributes;
using System;

namespace LocationParser.Commands.FileIO
{
	[Command(Name = "delete", Description = "Delete a previously save Timeline")]
	class DeleteCommand : MainCommand
	{
		[CommandArgument(1, Name = "name", Description = "The name of the Timeline to be deleted")]
		public string TimeLineName { get; set; }

		public override int OnExecute()
		{
			var store = new FileStore();
			if (string.IsNullOrWhiteSpace(TimeLineName))
			{
				Console.WriteLine(string.Join("\n", store.List()));
				return 1;
			}
			store.Delete(TimeLineName);
			return 0;
		}
	}
}
