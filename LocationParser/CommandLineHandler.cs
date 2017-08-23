using LocationParser.Commands;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.PlatformAbstractions;
using System.Linq;

namespace LocationParser
{
    internal class CommandLineHandler
    {
        private readonly CommandLineApplication app;

        public CommandLineHandler()
        {
            app = new CommandLineApplication();
            app.Name = PlatformServices.Default.Application.ApplicationName;
            app.Description = "Parser for a phone's location history";
            app.FullName = app.Description;

            var version = PlatformServices.Default.Application.ApplicationVersion ?? "unknown";
            app.HelpOption("-h|--help");
			
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            var factory = new CommandFactory(app);
            factory.Register<ReadCommand>();
        }
        public int Execute(string[] args)
        {
            if (!args.Any())
                app.ShowHelp();

            return app.Execute(args);
        }
    }
}
