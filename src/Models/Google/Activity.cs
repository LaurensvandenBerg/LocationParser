using System.Collections.Generic;

namespace LocationParser.Models.Google
{
	public class Activity
	{
		public string timestampMS;
		public IEnumerable<InnerActivity> activity;
	}
	public class InnerActivity
	{
		public string type;
		public string confidence;
	}
}