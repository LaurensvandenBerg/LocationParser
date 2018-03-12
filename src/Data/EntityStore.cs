using System.Collections.Generic;
using System.IO;
using LocationParser.Models.External;

namespace LocationParser.Data
{
	public class EntityStore : IDataStore
	{
		public void Copy(string nameFrom, string nameTo)
		{
			throw new System.NotImplementedException();
		}

		public void Load(string name)
		{
			throw new System.NotImplementedException();
		}

		public void Delete(string name)
		{
			throw new System.NotImplementedException();
		}
		public void Store(string name)
		{
			throw new System.NotImplementedException();
		}

		public void Store(string name, DirectoryInfo path)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<string> List()
		{
			throw new System.NotImplementedException();
		}

		public void Export(string name, IExternal exportType)
		{
			throw new System.NotImplementedException();
		}

		public void Export(string name, DirectoryInfo path, IExternal exportType)
		{
			throw new System.NotImplementedException();
		}
	}
}
