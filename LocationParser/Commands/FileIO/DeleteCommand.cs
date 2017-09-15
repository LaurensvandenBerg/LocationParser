using LocationParser.Data;
using Microsoft.Extensions.CommandLineUtils;

namespace LocationParser.Commands.FileIO
{
	class DeleteCommand : Command
	{
		public DeleteCommand(CommandLineApplication parent) : base(parent) { }

		public override void SetupCommand()
		{
			var deleteCommand = CreateCommand("delete", "Delete a previously save Timeline");

			var nameArgument = deleteCommand.Argument("name", "The name of the Timeline to be deleted");

			deleteCommand.OnExecute(() =>
			{
				var name = nameArgument.Value;

				if (string.IsNullOrWhiteSpace(name))
				{
					deleteCommand.ShowHelp();
					return 1;
				}
				new FileStore().Delete(name);
				return 0;
			});
		}
	}
}
