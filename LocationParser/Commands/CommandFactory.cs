using Microsoft.Extensions.CommandLineUtils;
using System;

namespace LocationParser.Commands
{
	public class CommandFactory
	{
		private CommandLineApplication app;

		public CommandFactory(CommandLineApplication app)
		{
			this.app = app;
		}

		public int Register<T>() where T : Command
		{
			((T)Activator.CreateInstance(typeof(T), app)).SetupCommand();
			return 0;
		}
	}
}
