using CommandLine;
using System;
using System.Collections.Generic;

namespace LocationParser.CommandLine.Options
{
	class FilterOptions
	{
		[Option("daterange", HelpText = "Select all entries between 2 given dates, given in format: DD-MM-YYYY <start:end>"
					, Min = 2, Max = 2, Separator = ':')]
		public IEnumerable<DateTime> DateRange { get; set; }

		[Option("timespan", HelpText = "Select all entries between a certain timespan, given in format: HH:mm:ss (24 hour clock) <start:end>"
					, Min = 2, Max = 2, Separator = ':')]
		public IEnumerable<DateTime> TimespanRange { get; set; }

		[Option("accuracy", HelpText = "Select all entries between a certain accuracy range <start:end>"
					, Min = 2, Max = 2, Separator = ':')]
		public IEnumerable<int> AccuracyRange { get; set; }
	}
}