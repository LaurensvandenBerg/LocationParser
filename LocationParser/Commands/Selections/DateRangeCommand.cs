using LocationParser.Current;
using LocationParser.Models.Internal;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Linq;

namespace LocationParser.Commands.Selections
{
	class DateRangeCommand : Command
	{
		public DateRangeCommand(CommandLineApplication parent) : base(parent) { }

		public override void SetupCommand()
		{
			var dateRangeCommand = CreateCommand("daterange", "Select all entries between 2 given dates, given in format: DD-MM-YYYY");
			var startDate = dateRangeCommand.Argument("startDate", "The day on which the selection starts.");
			var endDate = dateRangeCommand.Argument("endDate", "The day on which the selection ends.");

			dateRangeCommand.OnExecute(() =>
			{
				if (string.IsNullOrWhiteSpace(startDate.Value) || string.IsNullOrWhiteSpace(endDate.Value))
				{
					dateRangeCommand.ShowHelp();
					return 1;
				}

				var start = new DateTime();
				var end = new DateTime();

				if (!DateTime.TryParse(startDate.Value, out start) || !DateTime.TryParse(endDate.Value, out end))
				{
					dateRangeCommand.ShowHelp();
					return 1;
				}

				var timeLine = CurrentFile.Read();
				CurrentFile.Write(new TimeLine()
				{
					timeEntries = timeLine.timeEntries?.Where(e => e.timestamp.Date >= start.Date & e.timestamp.Date <= end.Date)
				});
				return 0;
			});
		}
	}
}
