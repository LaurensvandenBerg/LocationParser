using Microsoft.Extensions.CommandLineUtils;

namespace LocationParser.Commands
{
	public abstract class Command
	{
		protected CommandLineApplication app;

		protected Command(CommandLineApplication app)
		{
			this.app = app;
		}

		public abstract void SetupCommand();

		protected CommandLineApplication CreateCommand(string command, string description)
		{
			return CreateCommand(app, command, description);
		}

		protected CommandLineApplication CreateCommand(CommandLineApplication app, string command, string description)
		{
			return app.Command(command, c => {
				c.Description = description;
				c.FullName = app.Description;
				if (app.OptionHelp != null && app.OptionHelp.Template != null)
					c.HelpOption(app.OptionHelp?.Template);
			});
		}
	}
}
