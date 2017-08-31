using LocationParser.Current;
using LocationParser.Extensions.Models;
using LocationParser.Models.Google;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using System;
using System.IO;

namespace LocationParser.Commands.FileIO
{
	class ReadCommand : Command
	{
		public ReadCommand(CommandLineApplication app) : base(app) { }

		public override void SetupCommand()
		{
			var readCommand = CreateCommand("read", "Read a new Location history file");

			var fileArgument = readCommand.Argument("path", "The path of the JSON file with the locations.");

			readCommand.OnExecute(() =>
			{
				string file = fileArgument.Value;

				if (string.IsNullOrWhiteSpace(file))
				{
					readCommand.ShowHelp();
					return 1;
				}

				if (!File.Exists(file))
				{
					throw new Exception($"File at location: '{file}' not found.");
				}
				CurrentFile.Write(JsonConvert.DeserializeObject<Locations>(File.ReadAllText(file)).ToTimeLine());
				return 0;
			});
		}
	}
}
