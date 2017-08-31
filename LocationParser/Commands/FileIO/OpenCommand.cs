using LocationParser.Data;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Linq;

namespace LocationParser.Commands.FileIO
{
	class OpenCommand : Command
	{
		public OpenCommand(CommandLineApplication parent) : base(parent) { }

		public override void SetupCommand()
		{
			var openCommand = CreateCommand("open", "Open a previously saved file");

			var nameArgument = openCommand.Argument("name", "The name of the file to be opened");

			var store = new FileStore();

			openCommand.OnExecute(() =>
			{
				var name = nameArgument.Value;

				if (string.IsNullOrWhiteSpace(name))
				{
					Console.Write(string.Join("\n", store.List()));
					return 0;
				}
				new FileStore().Load(name);
				return 0;
			});
		}

	}
}
