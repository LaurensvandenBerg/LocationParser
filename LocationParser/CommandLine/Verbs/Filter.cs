using CommandLine;
using LocationParser.CommandLine.Options;
using LocationParser.Current;
using LocationParser.Models.Internal;
using System.Linq;

namespace LocationParser.CommandLine.Verbs
{
	[Verb("filter", HelpText = "Remove all Timeline entries which do not match the given filter")]
	class Filter
	{
		public int ParseOptions(FilterOptions options)
		{
			AccuracyFilter(options);
			DateTimeFilter(options);
			TimespanFilter(options);
			return 0;
		}

		private int AccuracyFilter(FilterOptions options)
		{
			var min = options.AccuracyRange.Item1;
			var max = options.AccuracyRange.Item2;

			var timeLine = CurrentFile.Read();
			CurrentFile.Write(new TimeLine()
			{
				timeEntries = timeLine.timeEntries?.Where(e => e.accuracy >= min && e.accuracy <= max)

			});
			return 0;
		}

		private int DateTimeFilter(FilterOptions options)
		{
			var start = options.DateRange.Item1;
			var end = options.DateRange.Item2;

			var timeLine = CurrentFile.Read();
			CurrentFile.Write(new TimeLine()
			{
				timeEntries = timeLine.timeEntries?.Where(e => e.timestamp.Date >= start.Date && e.timestamp.Date <= end.Date)

			});
			return 0;
		}

		private int TimespanFilter(FilterOptions options)
		{
			var start = options.TimespanRange.Item1;
			var end = options.TimespanRange.Item2;

			var timeLine = CurrentFile.Read();
			CurrentFile.Write(new TimeLine()
			{
				timeEntries = timeLine.timeEntries?.Where(e => e.timestamp.TimeOfDay >= start.TimeOfDay && e.timestamp.TimeOfDay <= end.TimeOfDay)
			});
			return 0;
		}
	}
}