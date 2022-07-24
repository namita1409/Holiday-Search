using FluentAssertions;
using HolidaySearch.JsonParser;
using HolidaySearch.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace HolidaySearchTest
{
    public class JsonFileParserTest
    {
        private IJsonFileParser jsonFileReader;

        [SetUp]
        public void Setup()
        {
            jsonFileReader = new JsonFileParser();
        }
        [Test]
        public void ParseHotelJsonString_Should_Return_HotelList()
        {
            List<Hotel> hotels = GetMockHotel();

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new CustomDateOnlyConverter("yyyy-MM-dd"));

            string jsonString = JsonSerializer.Serialize<List<Hotel>>(hotels, options);
            List<Hotel> result = jsonFileReader.ParseHotelJsonString(jsonString);

            result.First().Should().BeEquivalentTo(hotels.First());
        }
       
        [Test]
        public void ParseFlightJsonString_Should_Return_FlightList()
        {
            List<Flight> flights = GetMockFlight();

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new CustomDateOnlyConverter("yyyy-MM-dd"));

            string jsonString = JsonSerializer.Serialize<List<Flight>>(flights, options);
            List<Flight> result = jsonFileReader.ParseFlightJsonString(jsonString);

            result.First().Should().BeEquivalentTo(flights.First());
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
                }
            };
        }
        private List<Hotel> GetMockHotel()
        {
            return new List<Hotel>
            {
                new Hotel
                {
                    id = 9,
                    name = "Nh Malaga",
                    arrival_date = DateOnly.Parse("2023-07-01"),
                    price_per_night = 83,
                    local_airports = new List<string> { "AGP" },
                    nights = 7
                }
            };
        }
    }
}

