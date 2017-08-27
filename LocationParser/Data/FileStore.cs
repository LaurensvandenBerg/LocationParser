using LocationParser.Current;
using LocationParser.Extensions.Models;
using LocationParser.Models.Google;
using Newtonsoft.Json;
using System.IO;

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
			if (!File.Exists(name + ".json"))
			{
				throw new FileNotFoundException("Timeline with the name: " + name + " was not found");
			}
			CurrentFile.Write(JsonConvert.DeserializeObject<Locations>(File.ReadAllText(name + ".json")).ToTimeLine());
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
