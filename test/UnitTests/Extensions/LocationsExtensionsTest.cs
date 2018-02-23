using Newtonsoft.Json;
using LocationParser.Models.Google;
using LocationParserTests.Resources;
using LocationParser.Extensions.Models;
using System.Linq;
using System;
using LocationParser.Models.Internal;
using Xunit;

namespace LocationParserTests.UnitTests.Extensions
{
	public class LocationsExtensionsTest
	{
		Locations stubLocations;
		public LocationsExtensionsTest()
		{
			//GoogleTimeLine1 contains 5 data entries
			//Timestamps: 1, 2, 3, 4 and 5th of january 2017, all on 12:00:00
			//Coordinates: Amsterdam, Paris, London, Tokio, New York
			//No activities
			stubLocations = JsonConvert.DeserializeObject<Locations>(GoogleLocations.GoogleTimeLine1);
		}

		[Fact]
		public void LocationsToTimeLine_WhenConvertingALocationsModelToATimeLineModel_AllEntriesShouldBePreserved()
		{
			//Act
			var stubTimeLine = stubLocations.ToTimeLine();

			//Assert
			Assert.Equal(5, stubTimeLine.timeEntries.Count());
		}

		[Fact]
		public void LocationsToTimeEntry_WhenConvertingALocationsModelToATimeEntry_AllLocationInformationShouldBePreserved()
		{
			//Act
			var stubTimeEntries = stubLocations.ToTimeLine().timeEntries.Where(e => e.timestamp.DayOfYear == 1);

			//Assert
			Assert.Single(stubTimeEntries);

			var stubTimeEntry = stubTimeEntries.First();

			Assert.Equal(new DateTime(2017, 1, 1).DayOfYear, stubTimeEntry.timestamp.DayOfYear);
			Assert.Equal(new Coordinate() { latitude = 51.9905099, longitude = 4.3898283 }, stubTimeEntry.coordinate);
			Assert.Equal(20, stubTimeEntry.accuracy);
		}
		[Fact]
		public void GoogleActivityToInternalActivity_WhenConvertingActivityModels_AllDataShouldBePreserved()
		{
			//Arrange

			//Act

			//Assert
		}
	}
}
