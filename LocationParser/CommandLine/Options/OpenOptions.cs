using CommandLine;

namespace LocationParser.CommandLine.Options
{
	class OpenOptions
	{
		[Option("name", HelpText = "The name of the Timeline to be opened", Required = true)]
		public string name { get; set; }
	}
}