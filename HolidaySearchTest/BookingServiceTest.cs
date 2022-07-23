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
        public void GetFlightHotelList_Should_Throw_Exception_When_FlightList_Is_Null()
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
        public void GetFlightHotelList_Should_Throw_Exception_When_HotelList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = _JsonFileReader.FlightJonReader();

            //assert
            Assert.Throws<ArgumentNullException>(() => _BookingSearchService.GetFlightHotelList(
                                                                             flights, hotels, "MAN",
                                                                            "AGP", "2023/07/01", 7));
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
        public void GetFlightHotelListForAnyAirport_Should_Throw_Exception_When_FlightList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = null;

            //assert
            Assert.Throws<ArgumentNullException>(() => _BookingSearchService.GetFlightHotelListForAnyAirport(
                                                                                    flights, hotels,
                                                                                    "LPA", "2022/11/10", 14));
        }
        [Test]
        public void GetFlightHotelListForAnyAirport_Should_Throw_Exception_When_HotelList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = _JsonFileReader.FlightJonReader();

            //assert
            Assert.Throws<ArgumentNullException>(() => _BookingSearchService.GetFlightHotelListForAnyAirport(
                                                                                    flights, hotels, "LPA",
                                                                                    "2023/07/01", 14));
        }

        [Test]
        public void GetFlightHotelListAnyAirportFor_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = _JsonFileReader.FlightJonReader();
            int expectedFlightId = 7;
            int expectedHotelId = 6;

            //act
            IEnumerable<HolidayPackage> holidayPackages = _BookingSearchService.GetFlightHotelListForAnyAirport(
                                                                                flights, hotels,
                                                                                "LPA", "2022/11/10", 14);
            //assert
            holidayPackages.FirstOrDefault().flight.id.Should().Be(expectedFlightId);
            holidayPackages.FirstOrDefault().hotel.id.Should().Be(expectedHotelId);
        }
        [Test]
        public void GetFlightHotelListForAnyLondonAirport_Should_Throw_Exception_When_FlightList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = null;

            //assert
            Assert.Throws<ArgumentNullException>(() => _BookingSearchService.GetFlightHotelListForAnyLondonAirport(
                                                                                    flights, hotels,
                                                                                    "PMI", "2023/06/15", 10));
        }
        [Test]
        public void GetFlightHotelListForAnyLondonAirport_Should_Throw_Exception_When_HotelList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = _JsonFileReader.FlightJonReader();

            //assert
            Assert.Throws<ArgumentNullException>(() => _BookingSearchService.GetFlightHotelListForAnyLondonAirport(
                                                                                    flights, hotels, "PMI",
                                                                                    "2023/06/15", 10));
        }
        [Test]
        public void GetFlightHotelListForAnyLondonAirport_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = _JsonFileReader.FlightJonReader();
            int expectedFlightId = 6;
            int expectedHotelId = 5;

            //act
            IEnumerable<HolidayPackage> holidayPackages = _BookingSearchService.GetFlightHotelListForAnyAirport(
                                                                                flights, hotels,
                                                                                "PMI", "2023/06/15", 10);
            //assert
            holidayPackages.FirstOrDefault().flight.id.Should().Be(expectedFlightId);
            holidayPackages.FirstOrDefault().hotel.id.Should().Be(expectedHotelId);
        }
    }
}


