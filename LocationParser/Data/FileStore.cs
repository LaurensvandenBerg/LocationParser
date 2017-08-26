using LocationParser.Current;
using LocationParser.Extensions.Models;
using System;
using System.IO;

namespace LocationParser.Data
{
	class FileStore : IDataStore
	{
		private readonly string filePath = @"Storage\Files\";

		public void Copy(string nameFrom, string nameTo)
		{
			throw new NotImplementedException();
		}

		public void Load(string name)
		{
			throw new NotImplementedException();
		}

		public void Store(string name)
		{
			Store(name, filePath);
		}

		public void Store(string name, string path)
		{
			File.WriteAllText(path + name, CurrentFile.Read().ToLocations().ToString());
		}
	}
}
