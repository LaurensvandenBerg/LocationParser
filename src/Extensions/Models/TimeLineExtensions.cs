using LocationParser.Models.Google;
using LocationParser.Models.Internal;
using System.Collections.Generic;
using System.Linq;

namespace LocationParser.Extensions.Models
{
    public static class TimeLineExtensions
    {
		public static Locations ToLocations(this TimeLine timeLine) => new Locations
		{
			locations = timeLine?.timeEntries?.Select(e => e.ToLocation())
		};

		public static Location ToLocation(this TimeEntry entry) => new Location
		{
			timestampMS = entry.timestamp.ToEpoch().ToString(),
			latitudeE7 = (entry.coordinate.latitude * 10000000).ToString(),
			longitudeE7 = (entry.coordinate.longitude * 10000000).ToString(),
			altitude = entry.altitude.ToString(),
			accuracy = entry.accuracy.ToString(),
			activity = new[] { entry.movements?.ToActivity() }
		};
		public static Activity ToActivity(this IEnumerable<Movement> movements) => new Activity()
		{
			timestampMS = movements.First().timestamp.ToEpoch().ToString(),
			activity =  movements.Select(m => 
				new InnerActivity()
				{
					type = m.movementType.ToString(),
					confidence = m.confidence.ToString()
				})
		};
    }
}
