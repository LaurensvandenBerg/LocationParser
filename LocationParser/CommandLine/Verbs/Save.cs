using CommandLine;
using LocationParser.CommandLine.Options;
using LocationParser.Data;
using System.IO;

namespace LocationParser.CommandLine.Verbs
{
	[Verb("save", HelpText = "Save the current working TimeLine to with a specified name")]
	class Save
	{
		public int ParseOptions(SaveOptions options)
		{
			var name = options.name;
			var path = options.path;

			if (string.IsNullOrWhiteSpace(name))
			{
				//show help
				return 1;
			}

			var store = new FileStore();
			if (string.IsNullOrWhiteSpace(path))
			{
				store.Store(name);
			}
			else
			{
				var newPath = Directory.Exists(path) ? new DirectoryInfo(path) : Directory.CreateDirectory(path);
				store.Store(name, newPath);
			}
			return 0;
		}
	}
}