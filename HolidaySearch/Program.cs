// See https://aka.ms/new-console-template for more information
using HolidaySearch.JsonParser;
using HolidaySearch.Model;
using HolidaySearch.Search;


JsonFileReader f = new JsonFileReader();
List<Hotel> hotels= f.HoTelJsonReader();
List<Flight> flights = f.FlightJonReader();

BookingSearchService _Search = new BookingSearchService();

IEnumerable<Flight> flightList = _Search.GetFlightList(flights, "MAN", "AGP", "2023/07/01");
IEnumerable<Hotel> hotelList = _Search.GetHotelList(hotels,"AGP",7);
//Console.WriteLine(hotelList.ToList().Count);

foreach (Flight flight in flightList)
{
    Console.WriteLine(flight.toString());
}


Console.WriteLine(hotelList.First().toString());






/*Console.WriteLine($" count hotel {hotels.Count()}");
Console.WriteLine($" count flight {flights.Count()}");

DateOnly flightDate= DateOnly.Parse("2023/07/01");
string fromAirport = "MAN";
string toAirport = "AGP";
int nightsStay = 7;

//Query for flights
IEnumerable<Flight> resultAirline = flights.Where(f => f.from==fromAirport && f.to==toAirport&&f.departure_date.Equals(flightDate));

foreach (Flight flight in resultAirline)
{
    Console.WriteLine(flight.toString());
}

//Query for Hotels

IEnumerable<Hotel> resultHotel = hotels.Where(h =>
{
    List<String> localAirport = h.local_airports;
    foreach (String airport in localAirport)
    {
        if (airport.Equals(toAirport) && h.nights == nightsStay)
            return true;
    }
    return false;
}).OrderBy(h => h.price_per_night);
foreach (Hotel hotel in resultHotel)
{
    Console.WriteLine(hotel.toString());
}

Hotel hotelfound = resultHotel.First();
    Console.WriteLine(hotelfound.toString());
*/

