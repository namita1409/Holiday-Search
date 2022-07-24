using HolidaySearch.Model;

namespace HolidaySearch.JsonParser
{
    public interface IJsonFileParser
    {
        List<Flight> GetFlightsFromJsonFile(string fileName);
        List<Hotel> GetHotelsFromJsonFile(string fileName);
        List<Flight> ParseFlightJsonString(string jsonString);
        List<Hotel> ParseHotelJsonString(string jsonString);

    }
}