using LocationParser.Current;
using LocationParser.Extensions.Models;
using LocationParser.Models.Google;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using LocationParser.Models.External;

namespace LocationParser.Data
{
	class FileStore : IDataStore
	{
		private readonly DirectoryInfo filePath = !Directory.Exists(@"Storage\Files\") ? Directory.CreateDirectory(@"Storage\Files\") : new DirectoryInfo(@"Storage\Files\");

		public void Copy(string nameFrom, string nameTo)
		{
			Load(nameFrom);
			Store(nameTo);
		}

		public void Load(string name)
		{
			if (!File.Exists(filePath + name + ".json"))
			{
				throw new FileNotFoundException("Timeline with the name: " + name + ".json was not found");
			}
			CurrentFile.Write(JsonConvert.DeserializeObject<Locations>(File.ReadAllText(filePath + name + ".json")).ToTimeLine());
		}

		public void Delete(string name)
		{
			if (!File.Exists(filePath + name + ".json"))
			{
				throw new FileNotFoundException("Timeline with the name: " + name + ".json was not found");
			}
			File.Delete(filePath + name + ".json");
		}

		public void Store(string name)
		{
			Store(name, filePath);
		}

		public void Store(string name, DirectoryInfo path)
		{
			File.WriteAllText(path + name + ".json", CurrentFile.Read().ToLocations().ToString());
		}

		public void Export(string name, IExternal exportType)
		{
			Export(name, filePath, exportType);
		}

		public void Export(string name, DirectoryInfo path, IExternal exportType)
		{
			File.WriteAllText(path + name + ".json", exportType.ConvertFromTimeLine(CurrentFile.Read()).ToString());
		}

		public IEnumerable<string> List()
		{
			return filePath.EnumerateFiles().Select(fi => Path.GetFileNameWithoutExtension(fi.Name));
		}
	}
}
