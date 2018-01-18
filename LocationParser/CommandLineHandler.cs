using LocationParser.Commands;
using LocationParser.Commands.FileIO;
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
				ApplicationName = PlatformServices.Default.Application.ApplicationName,
				Description = "Parser for a phone's location history"
			};
		}

		public int Execute(string[] args)
		{
			if (!args.Any())
				//TODO: Show help
				return 1;

			return app.Execute(args);
		}
	}
}
