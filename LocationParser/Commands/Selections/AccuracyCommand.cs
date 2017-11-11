using LocationParser.Current;
using LocationParser.Models.Internal;
using Microsoft.Extensions.CommandLineUtils;
using System.Linq;

namespace LocationParser.Commands.Selections
{
	class AccuracyCommand : BaseSelectionCommand
	{
		public AccuracyCommand(CommandLineApplication parent) : base(parent)
		{
		}

		public override void SetupCommand()
		{
			var accuracyCommand = CreateCommand("accuracy", "Select all entries between a certain accuracy range");
			var minimumAccuracy = accuracyCommand.Argument("minimum", "The minimum value of accuracy");
			var maximumAccuracy = accuracyCommand.Argument("maximum", "The maximum value of accuracy");

			accuracyCommand.OnExecute(() =>
			{
				if (string.IsNullOrWhiteSpace(minimumAccuracy.Value) || string.IsNullOrWhiteSpace(maximumAccuracy.Value))
				{
					accuracyCommand.ShowHelp();
					return 1;
				}

				var min = 0;
				var max = 0;

				if (!int.TryParse(minimumAccuracy.Value, out min) || !int.TryParse(maximumAccuracy.Value, out max))
				{
					accuracyCommand.ShowHelp();
					return 1;
				}

				var timeLine = CurrentFile.Read();
				CurrentFile.Write(new TimeLine()
				{
					timeEntries = type == SelectionType.INCLUDE
						? timeLine.timeEntries?.Where(e => e.accuracy >= min && e.accuracy <= max)
						: timeLine.timeEntries?.Where(e => !(e.accuracy >= min) && !(e.accuracy <= max))

				});
				return 0;
			});
		}
	}
}
