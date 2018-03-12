using LocationParser.Commands.FileIO;
using LocationParser.Current;
using LocationParserTests.Resources;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace LocationParserTests.UnitTests.Commands.FileIO
{
	public class ReadCommandTests : IDisposable
	{
		StreamWriter file;
		string path = Directory.GetCurrentDirectory() + "testTimeLine";

		public ReadCommandTests()
		{
			file = new StreamWriter(path);
		}

		public void Dispose()
		{
			File.Delete(path);
		}

		[Fact]
		public void ReadCommand_WithPathToAGoogleTimeLine_LoadTimeLineIntoCurrentFile()
		{
			//Arrange
			//var CurrentFileMock = Mock.Of()

			//Act
			new ReadCommand().Execute(new[] { path });

			//Assert
			Assert.NotEmpty(CurrentFile.Read().timeEntries);
		}
	}
}
