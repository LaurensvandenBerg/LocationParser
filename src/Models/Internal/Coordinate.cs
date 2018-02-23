namespace LocationParser.Models.Internal
{
	public class Coordinate
	{
		public double latitude;
		public double longitude;

		public override bool Equals(object obj)
		{
			return Equals(obj as Coordinate);

		}

		public bool Equals(Coordinate coord)
		{
			if(coord != null)
			{
				return coord.latitude.Equals(latitude) && coord.longitude.Equals(longitude);
			}
			return false;
		}
	}
}
