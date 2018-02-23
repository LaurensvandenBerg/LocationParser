using LocationParser.Commands;
using Microsoft.Extensions.PlatformAbstractions;
using System.Linq;

namespace LocationParser
{
	internal class CommandLineHandler
	{
		private readonly MainCommand app;

		public CommandLineHandler()
		{
			app = new MainCommand
			{
				Description = "Parser for a phone's location history"
			};
			app.AppInfo.AppName = PlatformServices.Default.Application.ApplicationName;
		}

		public int Execute(string[] args)
		{
			if (!args.Any())
			{
				app.ShowHelp();
				return 1;
			}
			return app.Execute(args);
		}
	}
}
