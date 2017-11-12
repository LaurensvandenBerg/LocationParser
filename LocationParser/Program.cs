using System;
using CommandLine;
using LocationParser.CommandLine.Verbs;
using LocationParser.CommandLine.Options;

namespace LocationParser
{
	class Program
	{
		static int Main(string[] args)
		{
			return Parser.Default.ParseArguments<Delete, Filter, Open, Read, Save>(args)
				.MapResult(
					(DeleteOptions options) => new Delete().ParseOptions(options),
					(FilterOptions options) => new Filter().ParseOptions(options),
					(OpenOptions options) => new Open().ParseOptions(options),
					(ReadOptions options) => new Read().ParseOptions(options),
					(SaveOptions options) => new Save().ParseOptions(options),
					errs => 1);
		}
	}
}