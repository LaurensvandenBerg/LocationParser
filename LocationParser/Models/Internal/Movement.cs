using System;

namespace LocationParser.Models.Internal
{
	public class Movement
	{
		public DateTime timestamp;
		public int confidence;
		public MovementType movementType;
	}
}