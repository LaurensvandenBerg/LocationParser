using LocationParser.Data;
using Microsoft.Extensions.CommandLineUtils;
using System;

namespace LocationParser.Commands
{
	class SaveCommand : Command
	{
		public SaveCommand(CommandLineApplication parent) : base(parent) { }

		public override void SetupCommand()
		{
			var saveCommand = CreateCommand("save", "Save the current working TimeLine to with a specified name");

			var nameArgument = saveCommand.Argument("name", "The name of the TimeLine");

			var pathArgument = saveCommand.Argument("path", "optional path of the TimeLine");

			saveCommand.OnExecute(() =>
			{
				string name = nameArgument.Value;
				string path = pathArgument.Value;

				if (string.IsNullOrWhiteSpace(name))
				{
					saveCommand.ShowHelp();
					return 1;
				}

				var store = new FileStore();
				if (string.IsNullOrWhiteSpace(path))
				{
					store.Store(name);
				}
				else {
					store.Store(name, path);
				}
				return 0;
			});
		}
	}
}
