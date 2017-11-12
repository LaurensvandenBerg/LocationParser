using Microsoft.Extensions.CommandLineUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocationParser.Commands;
using System.Linq;

namespace LocationParserTests.UnitTests
{
	[TestClass]
	public class CommandFactoryTests
	{
		[TestMethod]
		public void CommandBinding_WhenRegisteringACommand_ItShouldBeDiscoverableByItsParent()
		{
			//Arrange
			var parentCommand = new CommandLineApplication();
			var factory = new CommandFactory(parentCommand);

			//Act
			factory.Register<StubCommand>();

			//Assert
			Assert.AreEqual(1,parentCommand.Commands.Count);
			Assert.AreEqual("stubCommand",parentCommand.Commands.FirstOrDefault().Name);
		}
		private class StubCommand : Verbs
		{
			public StubCommand(CommandLineApplication parent) : base(parent)
			{
			}

			public override void SetupCommand()
			{
				var stub = CreateCommand("stubCommand", "A stub Command used for testing");
			}
		}
	}
}
