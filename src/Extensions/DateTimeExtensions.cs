using System;

namespace LocationParser.Extensions
{
	public static class DateTimeExtensions
	{
		private readonly static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		public static DateTime FromEpoch(this DateTime datetime, long timestampMs) 
			=> epoch.AddMilliseconds(timestampMs);

		public static long ToEpoch(this DateTime datetime) => Convert.ToInt64((datetime - epoch).TotalMilliseconds);
	}
}
