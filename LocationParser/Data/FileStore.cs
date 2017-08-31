using LocationParser.Current;
using LocationParser.Extensions.Models;
using LocationParser.Models.Google;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LocationParser.Data
{
	class FileStore : IDataStore
	{
		private readonly string filePath = @"Storage\Files\";

		public void Copy(string nameFrom, string nameTo)
		{
			Load(nameFrom);
			Store(nameTo);
		}

		public void Load(string name)
		{
			if (!File.Exists(filePath + name + ".json"))
			{
				throw new FileNotFoundException("Timeline with the name: " + name + " was not found");
			}
			CurrentFile.Write(JsonConvert.DeserializeObject<Locations>(File.ReadAllText(filePath + name + ".json")).ToTimeLine());
		}

		public void Store(string name)
		{
			Store(name, filePath);
		}

		public void Store(string name, string path)
		{
			File.WriteAllText(path + name + ".json", CurrentFile.Read().ToLocations().ToString());
		}

		public IEnumerable<string> List()
		{
			return Directory.EnumerateFiles(filePath).Select(f => f.Split('\\').Last().Split('.').First());
		}
	}
}
