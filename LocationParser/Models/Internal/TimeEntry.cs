using System;
using System.Collections.Generic;

namespace LocationParser.Models.Internal
{
	public class TimeEntry
	{
		public DateTime timestamp;
		public Coordinate coordinate;
		public int accuracy;
		public int altitude;
		public IEnumerable<Movement> movements;
	}
}