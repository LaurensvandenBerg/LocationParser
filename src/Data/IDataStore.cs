using LocationParser.Models.External;
using System.Collections.Generic;
using System.IO;

namespace LocationParser.Data
{
	public interface IDataStore
	{
		void Store(string name);

		void Store(string name, DirectoryInfo path);

		void Export(string name, IExternal exportType);

		void Export(string name, DirectoryInfo path, IExternal exportType);

		void Load(string name);

		void Delete(string name);

		void Copy(string nameFrom, string nameTo);

		IEnumerable<string> List();
	}
}
