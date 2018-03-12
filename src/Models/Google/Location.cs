using System.Collections.Generic;

namespace LocationParser.Models.Google
{
    public class Location
    {
		public string timestampMS;
		public string latitudeE7;
		public string longitudeE7;
		public string accuracy;
		public string altitude;
		public IEnumerable<Activity> activity;
    }
}
