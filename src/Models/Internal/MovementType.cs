using System;
using System.Collections.Generic;
using System.Text;

namespace LocationParser.Models.Internal
{
    public enum MovementType
	{
		EXITING_VEHICLE,
        IN_RAIL_VEHICLE,
        IN_ROAD_VEHICLE,
		IN_VEHICLE,
		ON_BICYCLE,
		ON_FOOT,
		RUNNING,
		STILL,
		TILTING,
		UNKNOWN,
		WALKING,
		IN_TWO_WHEELER_VEHICLE,
		IN_FOUR_WHEELER_VEHICLE
	}
}
