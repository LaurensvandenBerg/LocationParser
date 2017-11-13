using CommandLine;

namespace LocationParser.CommandLine.Options
{
	class DeleteOptions
	{
		[Option("name", HelpText = "The name of the Timeline to be deleted", Required = true)]
		public string Name { get; set; }
	}
}