using System;
using System.Collections.Generic;
using System.Text;

namespace LocationParser.Models.Internal
{
    public enum MovementType
	{
		EXITING_VEHICLE,
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
