using HolidaySearch.Model;

namespace HolidaySearch.Search
{
    public interface IHolidaySearchService
    {
        IEnumerable<HolidayPackage> GetFlightHotelList(List<Flight> flights, List<Hotel> hotels, string departFrom, string travelTo, DateOnly date, int nightstoStay);
        IEnumerable<HolidayPackage> GetFlightsHotelsForAnyAirport(List<Flight> flights, List<Hotel> hotels, string travelTo, DateOnly date, int nightstoStay);
        IEnumerable<HolidayPackage> GetFlightsHotelsForAnyLondonAirport(List<Flight> flights, List<Hotel> hotels, string travelTo, DateOnly date, int nightstoStay);
    }
}