using LocationParser.Commands.Selections;
using Microsoft.Extensions.CommandLineUtils;

namespace LocationParser.Commands
{
	class FilterCommand : Command
	{
		public FilterCommand(CommandLineApplication parent) : base(parent) { }

		public override void SetupCommand()
		{
			var filterCommand = CreateCommand("filter", "Remove all Timeline entries which do not match the given filter");
			var factory = new CommandFactory(filterCommand);
			factory.Register<BaseSelectionCommand>();

			filterCommand.OnExecute(() =>
			{
				filterCommand.ShowHelp();
				return 0;
			});
		}
	}
}