using HolidaySearch.JsonParser;
using HolidaySearch.Model;
using HolidaySearch.Search;
using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchTest
{
    public class BookingServiceTest
    {
        private BookingSearchService _BookingSearchService;
        private JsonFileReader _JsonFileReader;

        [SetUp]
        public void Setup()
        {
            _BookingSearchService = new BookingSearchService();
            _JsonFileReader = new JsonFileReader();

        }


        [Test]
        public void GetFlightHotelList_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = _JsonFileReader.FlightJonReader();
            int expectedFlightId = 2;
            int expectedHotelId = 9;

            //act
            IEnumerable<HolidayPackage> holidayPackages = _BookingSearchService.GetFlightHotelList(
                                                                            flights, hotels, "MAN",
                                                                            "AGP", "2023/07/01", 7);
            //assert
            holidayPackages.FirstOrDefault().flight.id.Should().Be(expectedFlightId);
            holidayPackages.FirstOrDefault().hotel.id.Should().Be(expectedHotelId);
        }
        [Test]
        public void GetFlightHotelList_Should_Throw_ArgumentNullException_When_FlightList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = null;

            //assert
            Assert.Throws<ArgumentNullException>(() => _BookingSearchService.GetFlightHotelList(
                                                                             flights, hotels, "MAN",
                                                                            "AGP", "2023/07/01", 7));
        }

        [Test]
        public void GetFlightHotelList_Should_Throw_ArgumentNullException_When_HotelList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = _JsonFileReader.FlightJonReader();

            //assert
            Assert.Throws<ArgumentNullException>(() => _BookingSearchService.GetFlightHotelList(
                                                                             flights, hotels, "MAN",
                                                                             "AGP", "2023/07/01", 7));
        }
    }
}


