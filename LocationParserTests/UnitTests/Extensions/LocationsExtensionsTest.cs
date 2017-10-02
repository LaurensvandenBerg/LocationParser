using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using LocationParser.Models.Google;
using LocationParserTests.Resources;
using LocationParser.Extensions.Models;
using System.Linq;
using System;
using LocationParser.Models.Internal;

namespace LocationParserTests.UnitTests.Extensions
{
	[TestClass]
	public class LocationsExtensionsTest
	{
		Locations stubLocations;
		[TestInitialize]
		public void TestInit()
		{
			//GoogleTimeLine1 contains 5 data entries
			//Timestamps: 1, 2, 3, 4 and 5th of january 2017, all on 12:00:00
			//Coordinates: Amsterdam, Paris, London, Tokio, New York
			//No activities
			stubLocations = JsonConvert.DeserializeObject<Locations>(GoogleLocations.GoogleTimeLine1);
		}

		[TestMethod]
		public void LocationsToTimeLine_WhenConvertingALocationsModelToATimeLineModel_AllEntriesShouldBePreserved()
		{
			//Act
			var stubTimeLine = stubLocations.ToTimeLine();

			//Assert
			Assert.AreEqual(5, stubTimeLine.timeEntries.Count());
		}

		[TestMethod]
		public void LocationsToTimeEntry_WhenConvertingALocationsModelToATimeEntry_AllLocationInformationShouldBePreserved()
		{
			//Act
			var stubTimeEntries = stubLocations.ToTimeLine().timeEntries.Where(e => e.timestamp.DayOfYear == 1);

			//Assert
			Assert.AreEqual(1, stubTimeEntries.Count());

			var stubTimeEntry = stubTimeEntries.First();

			Assert.AreEqual(new DateTime(2017, 1, 1).DayOfYear, stubTimeEntry.timestamp.DayOfYear);
			Assert.AreEqual(new Coordinate() { latitude = 1.1, longitude = 1.1 }, stubTimeEntry.coordinate);
			Assert.AreEqual(20, stubTimeEntry.accuracy);
		}
		[TestMethod]
		public void GoogleActivityToInternalActivity_WhenConvertingActivityModels_AllDataShouldBePreserved()
		{
			//Arrange

			//Act

			//Assert
		}
	}
}
