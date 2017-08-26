using System;
using System.IO;

namespace LocationParser
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				var argumentSetup = new CommandLineHandler();
				argumentSetup.Execute(args);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				Console.ReadLine();
			}
		}
    }
}
