using LocationParser.Data;
using Microsoft.Extensions.CommandLineUtils;
using System;

namespace LocationParser.Commands.FileIO
{
	class OpenCommand : Command
	{
		public OpenCommand(CommandLineApplication parent) : base(parent) { }

		public override void SetupCommand()
		{
			var openCommand = CreateCommand("open", "Open a previously saved Timeline");

			var nameArgument = openCommand.Argument("name", "The name of the Timeline to be opened");

			openCommand.OnExecute(() =>
			{
				var name = nameArgument.Value;

				if (string.IsNullOrWhiteSpace(name))
				{
					var store = new FileStore();
					Console.Write(string.Join("\n", store.List()));
					return 0;
				}
				new FileStore().Load(name);
				return 0;
			});
		}
	}
}
