using ConsoleAppBase.Attributes;

namespace LocationParser.Commands
{
	[Command(Name = "filter", Description = "Remove all Timeline entries which do not match the given filter")]
	class FilterCommand : MainCommand
	{
		[CommandOption(Template = "--selectionType", Description = "Determine if you want to in- or exclude the given selection. Default is include. accepted values: <INCLUDE|EXCLUDE>")]
		protected SelectionType Type { get; set; }
	}
	enum SelectionType
	{
		INCLUDE,
		EXCLUDE
	}
}
