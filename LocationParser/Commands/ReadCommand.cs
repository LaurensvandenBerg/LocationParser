using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using System;
using System.IO;

namespace LocationParser.Commands
{
	class ReadCommand : Command
	{
		public ReadCommand(CommandLineApplication app) : base(app) { }

		public override void SetupCommand()
		{
			var readCommand = CreateCommand("read", "Read a new Location history file");

			var fileArgument = readCommand.Argument("file", "The JSON file with the locations.");

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
					throw new Exception($"File '{file}' not found.");
				}

				var parameters = JsonConvert.DeserializeObject(File.ReadAllText(file), typeof(string));

				return 0;
			});
		}
	}
}
