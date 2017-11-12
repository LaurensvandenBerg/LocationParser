using CommandLine;
namespace LocationParser.CommandLine.Options
{
	class ReadOptions
	{
		[Option("path", HelpText = "The path of the JSON file with the locations.", Required = true)]
		public string path { get; set; }
	}
}