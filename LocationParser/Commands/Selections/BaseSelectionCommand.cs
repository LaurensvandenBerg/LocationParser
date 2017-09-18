
using Microsoft.Extensions.CommandLineUtils;

namespace LocationParser.Commands.Selections
{
	class BaseSelectionCommand : Command
	{
		protected SelectionType type;
		public BaseSelectionCommand(CommandLineApplication parent) : base(parent) { }

		public override void SetupCommand()
		{
			var factory = new CommandFactory(parent);
			factory.Register<DateRangeCommand>();
			factory.Register<TimeSpanCommand>();
			//factory.Register<AreaCommand>();
		}

	}
	enum SelectionType
	{
		INCLUDE,
		EXCLUDE
	}
}
