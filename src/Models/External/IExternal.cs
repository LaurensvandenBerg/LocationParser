using LocationParser.Models.Internal;

namespace LocationParser.Models.External
{
	public interface IExternal
	{
		IExternal ConvertFromTimeLine(TimeLine timeLine);
	}
}
