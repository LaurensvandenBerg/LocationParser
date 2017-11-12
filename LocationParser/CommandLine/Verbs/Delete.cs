using CommandLine;
using LocationParser.CommandLine.Options;
using LocationParser.Data;

namespace LocationParser.CommandLine.Verbs
{
	[Verb("delete", HelpText="Delete a previously saved Timeline")]
	class Delete
	{
		public int ParseOptions(DeleteOptions options)
		{
			var name = options.name;

			if (string.IsNullOrWhiteSpace(name))
			{
				//show help
				return 1;
			}
			new FileStore().Delete(name);
			return 0;
		}
	}
}