using System;
using System.Collections.Generic;
using System.Text;

namespace LocationParser.Extensions
{
	public static class DateTimeExtensions
	{
		public static DateTime FromEpoch(this DateTime datetime, string timestampMs) 
			=> new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(Convert.ToInt64(timestampMs));
	}
}
