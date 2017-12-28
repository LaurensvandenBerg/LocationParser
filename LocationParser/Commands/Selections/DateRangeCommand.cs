using LocationParser.Current;
using LocationParser.Models.Internal;
using ConsoleAppBase;
using System;
using System.Linq;

namespace LocationParser.Commands.Selections
{
	[Command("daterange", Description = "Select all entries between 2 given dates, given in format: DD-MM-YYYY")]
	class DateRangeCommand : BaseSelectionCommand
	{
		[CommandArgument(1, Name = "startDate", Description = "The day on which the selection starts.", Required = true)]
		public DateTime StartDate { get; set; }

		[CommandArgument(2, Name = "endDate", Description = "The day on which the selection ends.", Required = true)]
		public DateTime EndDate { get; set; }

		public override int OnExecute()
		{
			var timeLine = CurrentFile.Read();
			switch (Type)
			{
				case SelectionType.INCLUDE:
					CurrentFile.Write(new TimeLine()
					{
						timeEntries = timeLine.timeEntries?.Where(e => e.timestamp.Date >= StartDate.Date && e.timestamp.Date <= EndDate.Date)
					});
					break;
				case SelectionType.EXCLUDE:
					CurrentFile.Write(new TimeLine()
					{
						timeEntries = timeLine.timeEntries?.Where(e => !(e.timestamp.Date >= StartDate.Date) && !(e.timestamp.Date <= EndDate.Date))
					});
					break;
				default:
					//TODO: Show help with type not found
					Console.WriteLine("TODO");
					break;
			}
			return 0;
		}
	}
}
