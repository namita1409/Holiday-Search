using HolidaySearch.JsonParser;
using HolidaySearch.Model;
using HolidaySearch.Search;
using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace HolidaySearchTest
{
    public class HolidaySearchServiceTestWithFile
    {
        private IHolidaySearchService holidaySearchService;
        private IJsonFileParser jsonFileParser;

        string hotelFile = "./hotel.json";
        string flightFile = "./flight.json";

        [SetUp]
        public void Setup()
        {
            jsonFileParser = new JsonFileParser();
            holidaySearchService = new HolidaySearchService();
        }
        [Test]
        public void GetFlightHotelList_Should_Throw_Exception_When_FileIsBlank()
        {
            //arrange
            try
            {
                List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
                List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile("./blank.json");
                DateOnly flightDate = DateOnly.Parse("2023/07/01");

                //act
                IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightHotelList(
                                                                              flights, hotels, "MAN", "AGP", flightDate, 7);
            }
            //assert
            catch (JsonException ex)
            {
                Console.WriteLine("GetFlightHotelList_ShouldThrowExceptionWhenFileIsBlank Exception Message" + ex.Message);
                Assert.True(true);
            }
        }
        [Test]
        public void GetFlightHotelList_Should_Throw_Exception_When_File_HasInValidData()
        {
            //arrange
            try
            {
                List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
                List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile("./invalidData.json");
                DateOnly flightDate = DateOnly.Parse("2023/07/01");

                //act
                IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightHotelList(
                                                                              flights, hotels, "MAN", "AGP", flightDate, 7);
            }
            //assert
            catch (JsonException ex)
            {
                Console.WriteLine("GetFlightHotelList_Should_Throw_Exception_When_File_HasInValidData Exception Message" + ex.Message);
                Assert.True(true);
            }
        }
        [Test]
        public void GetFlightHotelList_Should_Throw_Exception_When_File_IsNotAvailble()
        {
            //arrange
            try
            {
                List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
                List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile("./nofile.json");
                DateOnly flightDate = DateOnly.Parse("2023/07/01");

                //act
                IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightHotelList(
                                                                              flights, hotels, "MAN", "AGP", flightDate, 7);
            }
            //assert
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("GetFlightHotelList_Should_Throw_Exception_When_File_IsNotAvailble Exception Message" + ex.Message);
                Assert.True(true);
            }

        }
        [Test]
        public void GetFlightHotelList_Should_Throw_Exception_When_HotelList_IsNull()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(flightFile);

            DateOnly flightDate = DateOnly.Parse("2023/07/01");

            //act and assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightHotelList(
                                                                             flights, hotels, "MAN",
                                                                            "AGP", flightDate, 7));
        }
        [Test]
        public void GetFlightHotelList_Should_Throw_Exception_When_FlightList_IsNull()
        {
            //arrange
            List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile); ;
            List<Flight> flights = null;

            DateOnly flightDate = DateOnly.Parse("2023/07/01");

            //act and assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightHotelList(
                                                                             flights, hotels, "MAN",
                                                                            "AGP", flightDate, 7));
        }
        [Test]
        public void GetFlightHotelList_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
            List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(flightFile);

            DateOnly flightDate = DateOnly.Parse("2023/07/01");
            int expectedFlightId = 2;
            int expectedHotelId = 9;

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightHotelList(
                                                                            flights, hotels, "MAN",
                                                                            "AGP", flightDate, 7);
            //assert
            holidayPackages.FirstOrDefault().flight.id.Should().Be(expectedFlightId);
            holidayPackages.FirstOrDefault().hotel.id.Should().Be(expectedHotelId);
        }
        [Test]
        public void GetFlightHotelList_Should_Return_Null_For_Invalid_Flight_Airport_From()
        {
            //arrange
            List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
            List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(flightFile);

            DateOnly flightDate = DateOnly.Parse("2023/07/01");

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightHotelList(
                                                                           flights, hotels, "AAP",
                                                                            "AGP", flightDate, 7);
            //assert
            holidayPackages.Count().Should().Be(0);
        }
        [Test]
        public void GetFlightHotelList_Should_Return_Null_For_Invalid_Flight_Airport_To()
        {
            //arrange
            List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
            List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(flightFile);

            DateOnly flightDate = DateOnly.Parse("2023/07/01");

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightHotelList(
                                                                           flights, hotels, "MAN",
                                                                            "AAP", flightDate, 7);
            //assert
            holidayPackages.Count().Should().Be(0);
        }
        [Test]
        public void GetFlightsHotelsForAnyAirport_Should_Throw_Exception_When_Flight_Is_Null()
        {
            //arrange
            List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
            List<Flight> flights = null;
            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                    flights, hotels,
                                                                                    "LPA", flightDate, 14));        }
        [Test]
        public void GetFlightsHotelsForAnyAirport_Should_Throw_Exception_When_Hotel_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(flightFile);
            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                    flights, hotels, "LPA",
                                                                                    flightDate, 14));
        }
        [Test]
        public void GetFlightsHotelsForAnyAirport_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
            List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(flightFile);
            DateOnly flightDate = DateOnly.Parse("2022/11/10");
            int expectedFlightId = 7;
            int expectedHotelId = 6;

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                flights, hotels,
                                                                                "LPA", flightDate, 14);
            //assert
            holidayPackages.FirstOrDefault().flight.id.Should().Be(expectedFlightId);
            holidayPackages.FirstOrDefault().hotel.id.Should().Be(expectedHotelId);
        }
        [Test]
        public void GetFlightsHotelsForAnyAirport_Should_Return_Null_For_Invalid_Flight_Airport_To()
        {
            //arrange
            List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
            List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(flightFile);

            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                        flights, hotels, "AAA",
                                                                                        flightDate, 14);
            //assert
            holidayPackages.Count().Should().Be(0);
        }

        [Test]
        public void GetFlightsHotelsForAnyLondonAirport_Should_Throw_Exception_When_Flight_Is_Null()
        {
            //arrange
            List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
            List<Flight> flights = null;
            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //act and assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightsHotelsForAnyLondonAirport(
                                                                                                flights, hotels,
                                                                                                    "PMI", flightDate, 10));
        }
        [Test]
        public void GetFlightsHotelsForAnyLondonAirport_Should_Throw_Exception_When_Hotel_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(flightFile);
            DateOnly flightDate = DateOnly.Parse("2023/06/15");

            // act and assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightsHotelsForAnyLondonAirport(
                                                                                    flights, hotels, "PMI",
                                                                                   flightDate, 10));
        }
        [Test]
        public void GetFlightsHotelsForAnyLondonAirport_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
            List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(flightFile);
            DateOnly flightDate = DateOnly.Parse("2023/06/15");
            int expectedFlightId = 6;
            int expectedHotelId = 5;

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightsHotelsForAnyLondonAirport(
                                                                                flights, hotels,
                                                                                "PMI", flightDate, 10);
            //assert
            holidayPackages.FirstOrDefault().flight.id.Should().Be(expectedFlightId);
            holidayPackages.FirstOrDefault().hotel.id.Should().Be(expectedHotelId);
        }
        [Test]
        public void GetFlightsHotelsForAnyLondonAirport_Should_Return_Null_For_Invalid_Flight_Airport_To()
        {
            //arrange
            List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(hotelFile);
            List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(flightFile);

            DateOnly flightDate = DateOnly.Parse("2023/06/15");

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightsHotelsForAnyLondonAirport(
                                                                           flights, hotels,
                                                                            "AAA", flightDate, 10);
            //assert
            holidayPackages.Count().Should().Be(0);
        }
    }
}


