using FluentAssertions;
using HolidaySearch.Model;
using HolidaySearch.Search;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HolidaySearchTest
{
    public class HolidaySearchServiceTestUsingMock
    {
        private IHolidaySearchService holidaySearchService;

        [SetUp]
        public void Setup()
        {
            holidaySearchService = new HolidaySearchService();
        }
        [Test]        
        public void GetFlightHotelList_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = GetMockHotel();
            List<Flight> flights = GetMockFlight();
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
        public void GetFlightHotelList_Should_Throw_Exception_When_FlightList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = GetMockHotel();
            List<Flight> flights = null;
            DateOnly flightDate = DateOnly.Parse("2023/07/01");

            //assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightHotelList(
                                                                            flights, hotels, "MAN",
                                                                            "AGP", flightDate, 7));
        }
        [Test]
        public void GetFlightHotelList_Should_Throw_Exception_When_HotelList_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = GetMockFlight();
            DateOnly flightDate = DateOnly.Parse("2023/07/01");

            //act and assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightHotelList(
                                                                             flights, hotels, "MAN",
                                                                            "AGP", flightDate, 7));
        }
        [Test]
        public void GetFlightHotelList_Should_Return_Null_For_Invalid_FlightAirportFrom()
        {
            //arrange
            List<Hotel> hotels = GetMockHotel();
            List<Flight> flights = GetMockFlight();

            DateOnly flightDate = DateOnly.Parse("2023/07/01");

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightHotelList(
                                                                           flights, hotels, "AAP",
                                                                            "AGP", flightDate, 7);
            //assert
            holidayPackages.Count().Should().Be(0);
        }
        [Test]
        public void GetFlightHotelList_Should_Return_Null_For_Invalid_FlightAirportTo()
        {
            //arrange
            List<Hotel> hotels = GetMockHotel();
            List<Flight> flights = GetMockFlight();

            DateOnly flightDate = DateOnly.Parse("2023/07/01");

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightHotelList(
                                                                           flights, hotels, "MAN",
                                                                            "AAP", flightDate, 7);
            //assert
            holidayPackages.Count().Should().Be(0);
        }
        [Test]
        public void GetFlightsHotelsForAnyAirport_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = GetMockHotel();
            List<Flight> flights =GetMockFlight();
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
        public void GetFlightsHotelsForAnyAirport_Should_Throw_Exception_When_Flight_Is_Null()
        {
            //arrange
            List<Hotel> hotels = GetMockHotel();
            List<Flight> flights = null;
            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                    flights, hotels,
                                                                                    "LPA", flightDate, 14));
        }
        [Test]
        public void GetFlightsHotelsForAnyAirport_Should_Throw_Exception_When_Hotel_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = GetMockFlight();
            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                    flights, hotels, "LPA",
                                                                                    flightDate, 14));
        }
        [Test]
        public void GetFlightsHotelsForAnyAirport_Should_Return_Null_For_Invalid_FlightAirportTo()
        {
            //arrange
            List<Hotel> hotels = GetMockHotel();
            List<Flight> flights = GetMockFlight();

            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightsHotelsForAnyAirport(
                                                                                        flights, hotels, "AAA",
                                                                                        flightDate, 14);
            //assert
            holidayPackages.Count().Should().Be(0);
        }

       
        [Test]
        public void GetFlightsHotelsForAnyLondonAirport_Should_Return_Correct_Flight_And_Hotel_Id()
        {
            //arrange
            List<Hotel> hotels = GetMockHotel();
            List<Flight> flights = GetMockFlight();
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
        public void GetFlightsHotelsForAnyLondonAirport_Should_Throw_Exception_When_Flight_Is_Null()
        {
            //arrange
            List<Hotel> hotels = GetMockHotel();
            List<Flight> flights = null;
            DateOnly flightDate = DateOnly.Parse("2022/11/10");

            //assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightsHotelsForAnyLondonAirport(
                                                                                                flights, hotels,
                                                                                                    "PMI", flightDate, 10));
        }
        [Test]
        public void GetFlightsHotelsForAnyLondonAirport_Should_Throw_Exception_When_Hotel_Is_Null()
        {
            //arrange
            List<Hotel> hotels = null;
            List<Flight> flights = GetMockFlight();
            DateOnly flightDate = DateOnly.Parse("2023/06/15");

            //assert
            Assert.Throws<ArgumentNullException>(() => holidaySearchService.GetFlightsHotelsForAnyLondonAirport(
                                                                                    flights, hotels, "PMI",
                                                                                   flightDate, 10));
        }
        [Test]
        public void GetFlightsHotelsForAnyLondonAirport_Should_Return_Null_For_Invalid_FlightAirportTo()
        {
            //arrange
            List<Hotel> hotels = GetMockHotel();
            List<Flight> flights = GetMockFlight();

            DateOnly flightDate = DateOnly.Parse("2023/06/15");

            //act
            IEnumerable<HolidayPackage> holidayPackages = holidaySearchService.GetFlightsHotelsForAnyLondonAirport(
                                                                           flights, hotels,
                                                                            "AAA", flightDate, 10);
            //assert
            holidayPackages.Count().Should().Be(0);
        }
        private List<Hotel> GetMockHotel()
        {
            return new List<Hotel>
            {
                new Hotel {

                    id = 9,
                    name = "Nh Malaga",
                    arrival_date = DateOnly.Parse("2023-07-01"),
                    price_per_night = 83,
                    local_airports = new List<string> { "AGP" },
                    nights = 7
                },
                new Hotel {

                    id = 5,
                    name = "Sol Katmandu Park & Resort",
                    arrival_date = DateOnly.Parse("2023-06-15"),
                    price_per_night = 60,
                    local_airports = new List<string> { "PMI" },
                    nights = 10
                },
                new Hotel {

                    id = 6,
                    name = "Club Maspalomas Suites and Spa",
                    arrival_date = DateOnly.Parse("2022-11-10"),
                    price_per_night = 75,
                    local_airports = new List<string> { "LPA" },
                    nights = 14
                },
                 new Hotel {

                    id = 1,
                    name = "Iberostar Grand Portals Nous",
                    arrival_date = DateOnly.Parse("2022-11-05"),
                    price_per_night = 100,
                    local_airports = new List<string> { "TFS" },
                    nights = 7
                 }
            };

        }
        private List<Flight> GetMockFlight()
        {
            return new List<Flight>
            {
                new Flight
                {
                    id = 2,
                    airline = "Oceanic Airlines",
                    from ="MAN",
                    to = "AGP",
                    price = 245,
                    departure_date = DateOnly.Parse("2023-07-01")
                },
                new Flight
                {
                    id = 6,
                    airline = "Fresh Airways",
                    from ="LGW",
                    to = "PMI",
                    price = 75,
                    departure_date = DateOnly.Parse("2023-06-15")
                },
                new Flight
                {
                    id = 7,
                    airline = "Trans American Airlines",
                    from ="MAN",
                    to = "LPA",
                    price = 125,
                    departure_date = DateOnly.Parse("2022-11-10")
                },
                new Flight
                {
                    id = 3,
                    airline = "Trans American Airlines",
                    from = "MAN",
                    to = "PMI",
                    price = 170,
                    departure_date =DateOnly.Parse("2023-06-15")
                }
            };
        }

    }
}
