using LocationParser.Models.Internal;

namespace LocationParser.Data
{
    public interface IDataStore
    {
		void Store(string name, TimeLine timeLine);

		TimeLine Retrieve(string name);

		void Copy(string nameFrom, string nameTo);
    }
}
