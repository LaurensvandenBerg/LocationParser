using System;

namespace LocationParser.Models.Internal
{
	public class Movement
	{
		public DateTime timestamp;
		public int confidence;
		public enum movementType
		{
			IN_VEHICLE,
			ON_BICYCLE,
			ON_FOOT,
			RUNNING,
			STILL,
			TILTING,
			UNKNOWN,
			WALKING
		}
	}
}