using HolidaySearch.Model;

namespace HolidaySearch.JsonParser
{
    public interface IJsonFileReader
    {
        List<Flight> FlightJsonReader();
        List<Hotel> HotelJsonReader();
    }
}