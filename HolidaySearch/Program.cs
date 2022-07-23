// See https://aka.ms/new-console-template for more information
using HolidaySearch.JsonParser;
using HolidaySearch.Model;
using HolidaySearch.Search;


JsonFileReader jsonFileReader = new JsonFileReader();
List<Hotel> hotels= jsonFileReader.HoTelJsonReader();
List<Flight> flights = jsonFileReader.FlightJonReader();


BookingSearchService _BookingSearchService = new BookingSearchService();
IEnumerable<HolidayPackage> holidayPackages;

//////Test case 1
holidayPackages = _BookingSearchService.GetFlightHotelList(flights, hotels, "MAN", "AGP", "2023 / 07 / 01", 7);
Console.WriteLine("*****************************************");
Console.WriteLine(holidayPackages.First().flight.toString());
Console.WriteLine("#########################################");
Console.WriteLine(holidayPackages.First().hotel.toString());
Console.WriteLine("*****************************************");
////Test case 2
Console.WriteLine("*****************************************");
holidayPackages = _BookingSearchService.GetFlightListForAnyLondonAirport(flights, hotels, "PMI", "2023/06/15", 10);
Console.WriteLine(holidayPackages.First().flight.toString());
Console.WriteLine("#########################################");
Console.WriteLine(holidayPackages.First().hotel.toString());
Console.WriteLine("*****************************************");

////Test case 3
Console.WriteLine("*****************************************");
holidayPackages = _BookingSearchService.GetFlightHotelListForAnyAirport(flights, hotels, "LPA", "2022/11/10", 14);
Console.WriteLine(holidayPackages.First().flight.toString());
Console.WriteLine("#########################################");
Console.WriteLine(holidayPackages.First().hotel.toString());
Console.WriteLine("*****************************************");


