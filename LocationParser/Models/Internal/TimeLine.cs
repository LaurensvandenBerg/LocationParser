using Newtonsoft.Json;
using System.Collections.Generic;

namespace LocationParser.Models.Internal
{
    public class TimeLine
    {
		public IEnumerable<TimeEntry> timeEntries;

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
