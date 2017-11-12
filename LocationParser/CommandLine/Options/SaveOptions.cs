using CommandLine;

namespace LocationParser.CommandLine.Options
{
	class SaveOptions
	{
		[Option("name", HelpText = "The name of the TimeLine", Required = true)]
		public string name { get; set; }

		[Option("path", HelpText = "optional path of the TimeLine")]
		public string path { get; set; }
	}
}