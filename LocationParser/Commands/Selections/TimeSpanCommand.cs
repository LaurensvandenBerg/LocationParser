using LocationParser.Current;
using LocationParser.Models.Internal;
using ConsoleAppBase;
using System;
using System.Linq;

namespace LocationParser.Commands.Selections
{
	[Command("timespan", Description = "Select all entries between a certain timespan, given in format: HH:mm:ss (24 hour clock)")]
	class TimeSpanCommand : FilterCommand
	{
		[CommandArgument(1, Name = "startTime", Description = "The time on which the selection starts.", Required = true)]
		public DateTime StartTime { get; set; }

		[CommandArgument(2, Name = "endTime", Description = "The time on which the selection ends.", Required = true)]
		public DateTime EndTime { get; set; }

		public override int OnExecute()
		{
			var timeLine = CurrentFile.Read();
			switch (Type)
			{
				case SelectionType.INCLUDE:
					CurrentFile.Write(new TimeLine()
					{
						timeEntries = timeLine.timeEntries?.Where(e => e.timestamp.TimeOfDay >= StartTime.TimeOfDay && e.timestamp.TimeOfDay <= EndTime.TimeOfDay)
					});
					break;
				case SelectionType.EXCLUDE:
					CurrentFile.Write(new TimeLine()
					{
						timeEntries = timeLine.timeEntries?.Where(e => !(e.timestamp.TimeOfDay >= StartTime.TimeOfDay) && !(e.timestamp.TimeOfDay <= EndTime.TimeOfDay))
					});
					break;
				default:
					Console.WriteLine(HelpText);
					break;
			}
			return 0;
		}
	}
}
