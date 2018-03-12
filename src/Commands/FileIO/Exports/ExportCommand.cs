using ConsoleAppBase.Attributes;
using LocationParser.Data;
using LocationParser.Models.External;

namespace LocationParser.Commands.FileIO.Exports
{
	[Command(Name = "export", Description = "Strip all unnecessary data for exporting to other services WARNING: REMOVES ABILITY TO FILTER ON CERTAIN ASPECTS")]
	class ExportCommand : MainCommand
	{
		[CommandArgument(1, Name = "service-name", Description = "name of the service you want to export to", Required = true)]
		public string ServiceName { get; set; }

		public override int OnExecute()
		{
			if (ServiceName == "visualizer")
			{
				var Store = new FileStore();

				Store.Export("export", new Visualizer());

				return 0;
			}
			return 1;
		}
	}
}
