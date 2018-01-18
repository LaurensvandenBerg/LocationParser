using ConsoleAppBase;

namespace LocationParser.Commands
{
	[Command("filter", Description = "Remove all Timeline entries which do not match the given filter")]
	class FilterCommand : MainCommand
	{
		[CommandOption(Template = "--selectionType",
						Name = "selection type",
						Description = "Determine if you want to in- or exclude the given selection. Default is include. accepted values: <INCLUDE|EXCLUDE>",
						Type = CommandOptionType.SingleValue)]
		protected SelectionType Type { get; set; }
	}
	enum SelectionType
	{
		INCLUDE,
		EXCLUDE
	}
}
