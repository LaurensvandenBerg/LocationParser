using LocationParser.Models.Internal;

namespace LocationParser.Data
{
    public interface IDataStore
    {
		void Store(string name);

		void Store(string name, string path);

		void Load(string name);

		void Copy(string nameFrom, string nameTo);
    }
}
