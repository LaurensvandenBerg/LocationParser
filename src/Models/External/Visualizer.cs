using LocationParser.Models.Internal;
using System.Collections.Generic;
using LocationParser.Extensions.Models;
using System.Linq;
using Newtonsoft.Json;

namespace LocationParser.Models.External
{
	public class Visualizer : IExternal
	{
		public IEnumerable<Location> locations;

		public IExternal ConvertFromTimeLine(TimeLine timeLine)
		{
			locations = timeLine.timeEntries.Select(e => new Location()
			{
				latitudeE7 = e.ToLocation().latitudeE7,
				longitudeE7 = e.ToLocation().longitudeE7
			});
			return this;
		}
		
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
	public class Location
	{
		public string latitudeE7;
		public string longitudeE7;
	}
}
