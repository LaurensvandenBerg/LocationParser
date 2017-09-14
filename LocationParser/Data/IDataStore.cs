using System.Collections.Generic;
using System.IO;

namespace LocationParser.Data
{
	public interface IDataStore
	{
		void Store(string name);

		void Store(string name, DirectoryInfo path);

		void Load(string name);

		void Copy(string nameFrom, string nameTo);

		IEnumerable<string> List();
	}
}
