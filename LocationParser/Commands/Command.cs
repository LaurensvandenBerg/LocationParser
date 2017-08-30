using Microsoft.Extensions.CommandLineUtils;

namespace LocationParser.Commands
{
	public abstract class Command
	{
		protected CommandLineApplication parent;

		protected Command(CommandLineApplication parent)
		{
			this.parent = parent;
		}

		public abstract void SetupCommand();

		protected CommandLineApplication CreateCommand(string command, string description)
		{
			return CreateCommand(parent, command, description);
		}

		protected CommandLineApplication CreateCommand(CommandLineApplication parent, string command, string description)
		{
			return parent.Command(command, c => {
				c.Description = description;
				c.FullName = parent.Description;
				if (parent.OptionHelp != null && parent.OptionHelp.Template != null)
					c.HelpOption(parent.OptionHelp?.Template);
			});
		}
	}
}
