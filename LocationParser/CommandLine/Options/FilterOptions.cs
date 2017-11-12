using CommandLine;
using System;

namespace LocationParser.CommandLine.Options
{
	class FilterOptions
	{
		[Option("daterange", HelpText = "Select all entries between 2 given dates, given in format: DD-MM-YYYY")]
		public Tuple<DateTime, DateTime> DateRange { get; set; }

		[Option("timespan", HelpText = "Select all entries between a certain timespan, given in format: HH:mm:ss (24 hour clock)")]
		public Tuple<DateTime, DateTime> TimespanRange { get; set; }

		[Option("accuracy", HelpText = "Select all entries between a certain accuracy range")]
		public Tuple<int, int> AccuracyRange { get; set; }
	}
}