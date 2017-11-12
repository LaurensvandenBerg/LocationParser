using CommandLine;
using LocationParser.CommandLine.Options;
using LocationParser.Current;
using LocationParser.Extensions.Models;
using LocationParser.Models.Google;
using Newtonsoft.Json;
using System;
using System.IO;

namespace LocationParser.CommandLine.Verbs
{
	[Verb("read", HelpText = "Read a new Location history file")]
	class Read
	{
		public int ParseOptions(ReadOptions options)
		{
			string file = options.path;

			if (string.IsNullOrWhiteSpace(file))
			{
				//show help
				return 1;
			}

			if (!File.Exists(file))
			{
				throw new Exception($"File at location: '{file}' not found.");
			}
			CurrentFile.Write(JsonConvert.DeserializeObject<Locations>(File.ReadAllText(file)).ToTimeLine());
			return 0;
		}
	}
}