using LocationParser.Models.Internal;
using Newtonsoft.Json;
using System.IO;

namespace LocationParser.Current
{
    public static class CurrentFile
    {
		public static TimeLine Read() => JsonConvert.DeserializeObject<TimeLine>(File.ReadAllText(@"Current\currentTimeLine.json"));

		public static void Write(TimeLine timeLine) => File.WriteAllText(@"Current\currentTimeLine.json", JsonConvert.SerializeObject(timeLine));
	}
}
