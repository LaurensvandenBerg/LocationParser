using CommandLine;
using LocationParser.CommandLine.Options;
using LocationParser.Data;
using System;

namespace LocationParser.CommandLine.Verbs
{
	[Verb("open", HelpText = "Open a previously saved Timeline")]
	class Open : OpenOptions
	{
		public int ParseOptions(OpenOptions options)
		{
			var name = options.Name;

			if (string.IsNullOrWhiteSpace(name))
			{
				var store = new FileStore();
				Console.Write(string.Join("\n", store.List()));
				return 0;
			}
			new FileStore().Load(name);
			return 0;
		}
	}
}