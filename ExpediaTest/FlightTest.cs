using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
        {
            DateTime start = new DateTime(2012, 12, 31);
            DateTime end = new DateTime(2013, 1, 1);
            var target = new Flight(start, end, 200);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayFlight()
        {
            DateTime start = new DateTime(2012, 12, 31);
            DateTime end = new DateTime(2013, 1, 2);
            var target = new Flight(start, end, 200);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayFlight()
        {
            DateTime start = new DateTime(2012, 12, 31);
            DateTime end = new DateTime(2013, 1, 5);
            var target = new Flight(start, end, 200);
            Assert.AreEqual(300, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceFor365DayFlight()
        {
            DateTime start = new DateTime(2012, 12, 31);
            DateTime end = new DateTime(2013, 12, 31);
            var target = new Flight(start, end, 200);
            Assert.AreEqual(365*20+200, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightStartIsBeforeFlightEnd()
        {
            DateTime start = new DateTime(2012, 12, 31);
            DateTime end = new DateTime(2012, 12, 30);
            var target = new Flight(start, end, 200);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightMilesIsPositive()
        {
            DateTime start = new DateTime(2012, 12, 31);
            DateTime end = new DateTime(2013, 1, 1);
            var target = new Flight(start, end, -200);
        }

	}
}
