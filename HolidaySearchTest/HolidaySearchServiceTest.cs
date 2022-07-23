using HolidaySearch.JsonParser;
using HolidaySearch.Model;
using HolidaySearch.Search;
using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HolidaySearchTest
{
    public class HolidaySearchServiceTest
    {
        private HolidaySearchService _HolidaySearchService;
        private JsonFileReader _JsonFileReader;

        [SetUp]
        public void Setup()
        {
            _HolidaySearchService = new HolidaySearchService();
            _JsonFileReader = new JsonFileReader();

        }
        [Test]
        public void GetFlightHotelList_Should_Throw_Exception_When_FlightList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = null;            
            DateOnly flightDate = DateOnly.Parse("2023/07/01");

            //assert
            Assert.Throws<ArgumentNullException>(() => _HolidaySearchService.GetFlightHotelList(
                                                                            flights, hotels, "MAN",
                                                                            "AGP", flightDate, 7));
        }
        [Test]
        public void GetFlightHotelList_Should_Throw_Exception_When_HotelList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = _JsonFileReader.FlightJsonReader();
          
            DateOnly flightDate = DateOnly.Parse("2023/07/01");

            //assert
            Assert.Throws<ArgumentNullException>(() => _HolidaySearchService.GetFlightHotelList(
                                                                             flights, hotels, "MAN",
                                                                            "AGP", flightDate, 7));
        }
        [Test]
        public void GetFlightHotelList_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = _JsonFileReader.FlightJsonReader();
            
            DateOnly flightDate = DateOnly.Parse("2023/07/01");
            int expectedFlightId = 2;
            int expectedHotelId = 9;

            //act
            IEnumerable<HolidayPackage> holidayPackages = _HolidaySearchService.GetFlightHotelList(
                                                                            flights, hotels, "MAN",
                                                                            "AGP", flightDate, 7);
            //assert
            holidayPackages.FirstOrDefault().flight.id.Should().Be(expectedFlightId);
            holidayPackages.FirstOrDefault().hotel.id.Should().Be(expectedHotelId);
        }
        [Test]
        public void GetFlightsHotelsForAnyAirport_Should_Throw_Exception_When_Flight_Is_Null()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = null;          
            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //assert
            Assert.Throws<ArgumentNullException>(() => _HolidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                    flights, hotels,
                                                                                    "LPA", flightDate, 14));
        }
        [Test]
        public void GetFlightsHotelsForAnyAirport_Should_Throw_Exception_When_Hotel_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = _JsonFileReader.FlightJsonReader();          
            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //assert
            Assert.Throws<ArgumentNullException>(() => _HolidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                    flights, hotels, "LPA",
                                                                                    flightDate, 14));
        }

        [Test]
        public void GetFlightsHotelsAnyAirportFor_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = _JsonFileReader.FlightJsonReader();            
            DateOnly flightDate = DateOnly.Parse("2022/11/10");
            int expectedFlightId = 7;
            int expectedHotelId = 6;

            //act
            IEnumerable<HolidayPackage> holidayPackages = _HolidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                flights, hotels,
                                                                                "LPA", flightDate, 14);
            //assert
            holidayPackages.FirstOrDefault().flight.id.Should().Be(expectedFlightId);
            holidayPackages.FirstOrDefault().hotel.id.Should().Be(expectedHotelId);
        }
        [Test]
        public void GetFlightsHotelsForAnyLondonAirport_Should_Throw_Exception_When_Flight_Is_Null()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = null;
            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //assert
            Assert.Throws<ArgumentNullException>(() => _HolidaySearchService.GetFlightsHotelsForAnyLondonAirport(
                                                                                    flights, hotels,
                                                                                    "PMI", flightDate, 10));
        }
        [Test]
        public void GetFlightsHotelsForAnyLondonAirport_Should_Throw_Exception_When_Hotel_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = _JsonFileReader.FlightJsonReader();
            DateOnly flightDate = DateOnly.Parse("2023/06/15");

            //assert
            Assert.Throws<ArgumentNullException>(() => _HolidaySearchService.GetFlightsHotelsForAnyLondonAirport(
                                                                                    flights, hotels, "PMI",
                                                                                   flightDate, 10));
        }
        [Test]
        public void GetFlightsHotelsForAnyLondonAirport_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = _JsonFileReader.HoTelJsonReader();
            List<Flight> flights = _JsonFileReader.FlightJsonReader();
            DateOnly flightDate = DateOnly.Parse("2023/06/15");
            int expectedFlightId = 6;
            int expectedHotelId = 5;

            //act
            IEnumerable<HolidayPackage> holidayPackages = _HolidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                flights, hotels,
                                                                                "PMI", flightDate, 10);
            //assert
            holidayPackages.FirstOrDefault().flight.id.Should().Be(expectedFlightId);
            holidayPackages.FirstOrDefault().hotel.id.Should().Be(expectedHotelId);
        }
    }
}


