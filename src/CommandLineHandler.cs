using LocationParser.Commands;
using Microsoft.Extensions.PlatformAbstractions;
using System;
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
				ApplicationName = PlatformServices.Default.Application.ApplicationName,
				Description = "Parser for a phone's location history"
			};
		}

		public int Execute(string[] args)
		{
			if (!args.Any())
			{
				Console.WriteLine(app.HelpText);
				return 1;
			}
			return app.Execute(args);
		}
	}
}
