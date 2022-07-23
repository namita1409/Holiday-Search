// See https://aka.ms/new-console-template for more information
using HolidaySearch.JsonParser;
using HolidaySearch.Model;
using HolidaySearch.Search;


IJsonFileReader jsonFileReader = new JsonFileReader();
List<Hotel> hotels = jsonFileReader.HotelJsonReader();
List<Flight> flights = jsonFileReader.FlightJsonReader();


IHolidaySearchService _HolidaySearchService = new HolidaySearchService();
IEnumerable<HolidayPackage> holidayPackages;

////Test case 1
DateOnly flightDate1 = DateOnly.Parse("2023/07/01");
holidayPackages = _HolidaySearchService.GetFlightHotelList(flights, hotels, "MAN", "AGP", flightDate1, 7);
Console.WriteLine("*****************************************");
Console.WriteLine(holidayPackages.First().flight.toString());
Console.WriteLine("#########################################");
Console.WriteLine(holidayPackages.First().hotel.toString());
Console.WriteLine("*****************************************");

////Test case 2
Console.WriteLine("*****************************************");
DateOnly flightDate2 = DateOnly.Parse("2023/06/15");
holidayPackages = _HolidaySearchService.GetFlightsHotelsForAnyLondonAirport(flights, hotels, "PMI", flightDate2, 10);
Console.WriteLine(holidayPackages.First().flight.toString());
Console.WriteLine("#########################################");
Console.WriteLine(holidayPackages.First().hotel.toString());
Console.WriteLine("*****************************************");

////Test case 3
Console.WriteLine("*****************************************");
DateOnly flightDate3 = DateOnly.Parse("2022/11/10");
holidayPackages = _HolidaySearchService.GetFlightsHotelsForAnyAirport(flights, hotels, "LPA", flightDate3, 14);
Console.WriteLine(holidayPackages.First().flight.toString());
Console.WriteLine("#########################################");
Console.WriteLine(holidayPackages.First().hotel.toString());
Console.WriteLine("*****************************************");


