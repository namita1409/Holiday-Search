// See https://aka.ms/new-console-template for more information
using HolidaySearch.JsonParser;
using HolidaySearch.Model;
using HolidaySearch.Search;

string fileNameH = @"D:/Learning/OnTheBeachTechTask/OnTheBeach/HolidaySearch/Input/hotel.json";
string fileNameF = @"D:/Learning/OnTheBeachTechTask/OnTheBeach/HolidaySearch/Input/flight.json";
IJsonFileParser jsonFileParser = new JsonFileParser();

List<Hotel> hotels = jsonFileParser.GetHotelsFromJsonFile(fileNameH);
List<Flight> flights = jsonFileParser.GetFlightsFromJsonFile(fileNameF);


IHolidaySearchService holidaySearchService = new HolidaySearchService();
IEnumerable<HolidayPackage> holidayPackages;

////Test case 1
DateOnly flightDate1 = DateOnly.Parse("2023/07/01");
holidayPackages = holidaySearchService.GetFlightHotelList(flights, hotels, "MAN", "AGP", flightDate1, 7);
Console.WriteLine("*****************************************");

Console.WriteLine(holidayPackages.First().flight.toString());
Console.WriteLine("#########################################");
Console.WriteLine(holidayPackages.First().hotel.toString());
Console.WriteLine("*****************************************");

////Test case 2
Console.WriteLine("*****************************************");
DateOnly flightDate2 = DateOnly.Parse("2023/06/15");
holidayPackages = holidaySearchService.GetFlightsHotelsForAnyLondonAirport(flights, hotels, "PMI", flightDate2, 10);
Console.WriteLine(holidayPackages.First().flight.toString());
Console.WriteLine("#########################################");
Console.WriteLine(holidayPackages.First().hotel.toString());
Console.WriteLine("*****************************************");

////Test case 3
Console.WriteLine("*****************************************");
DateOnly flightDate3 = DateOnly.Parse("2022/11/10");
holidayPackages = holidaySearchService.GetFlightsHotelsForAnyAirport(flights, hotels, "LPA", flightDate3, 14);
Console.WriteLine(holidayPackages.First().flight.toString());
Console.WriteLine("#########################################");
Console.WriteLine(holidayPackages.First().hotel.toString());
Console.WriteLine("*****************************************");


