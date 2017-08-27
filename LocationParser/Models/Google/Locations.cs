using Newtonsoft.Json;
using System.Collections.Generic;

namespace LocationParser.Models.Google
{
    public class Locations
    {
		public IEnumerable<Location> locations;

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
