using LocationParser.Current;
using LocationParser.Models.Internal;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Linq;

namespace LocationParser.Commands.Selections
{
	class TimeSpanCommand : BaseSelectionCommand
	{
		public TimeSpanCommand(CommandLineApplication parent) : base(parent) { }

		public override void SetupCommand()
		{
			var timeSpanCommand = CreateCommand("timespan", "Select all entries between a certain timespan, given in format: HH:mm:ss (24 hour clock)");
			var startTime = timeSpanCommand.Argument("startTime", "The time on which the selection starts.");
			var endTime = timeSpanCommand.Argument("endTime", "The time on which the selection ends.");

			timeSpanCommand.OnExecute(() =>
			{
				if (string.IsNullOrWhiteSpace(startTime.Value) || string.IsNullOrWhiteSpace(endTime.Value))
				{
					timeSpanCommand.ShowHelp();
					return 1;
				}

				var start = new DateTime();
				var end = new DateTime();

				if (!DateTime.TryParse(startTime.Value, out start) || !DateTime.TryParse(endTime.Value, out end))
				{
					timeSpanCommand.ShowHelp();
					return 1;
				}

				var timeLine = CurrentFile.Read();
				CurrentFile.Write(new TimeLine()
				{
					timeEntries = type == SelectionType.INCLUDE
					? timeLine.timeEntries?.Where(e => e.timestamp.TimeOfDay >= start.TimeOfDay && e.timestamp.TimeOfDay <= end.TimeOfDay)
					: timeLine.timeEntries?.Where(e => !(e.timestamp.TimeOfDay >= start.TimeOfDay) && !(e.timestamp.TimeOfDay <= end.TimeOfDay))
				});
				return 0;
			});
		}
	}
}
