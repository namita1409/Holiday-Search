
using HolidaySearch.Model;

namespace HolidaySearch.Search
{
    public class HolidaySearchService
    {
        public IEnumerable<HolidayPackage> GetFlightHotelList(List<Flight> flights, List<Hotel> hotels, string departFrom, string travelTo, DateOnly date, int nightstoStay)
        {
            if (flights == null || hotels == null)
                throw new ArgumentNullException("list is null please check your code");              
                
                IEnumerable<Flight> flightSearchresults = GetFlightList(flights, departFrom, travelTo, date);
                IEnumerable<Hotel> hotelSearchResults = getHotelList(hotels, travelTo, nightstoStay);
                
            return holidayPackage(flightSearchresults, hotelSearchResults);            
        }
        public IEnumerable<HolidayPackage> GetFlightsHotelsForAnyAirport(List<Flight> flights, List<Hotel> hotels, string travelTo, DateOnly date, int nightstoStay)
        {
              if (flights == null || hotels == null)
                    throw new ArgumentNullException("list is null please check your code ");
               
                IEnumerable<Flight> flightSearchresults = GetFlightListForAnyAirport(flights, travelTo, date);
                IEnumerable<Hotel> hotelSearchResults = getHotelList(hotels, travelTo, nightstoStay);

             return holidayPackage(flightSearchresults, hotelSearchResults); 
        }
        public IEnumerable<HolidayPackage> GetFlightsHotelsForAnyLondonAirport(List<Flight> flights, List<Hotel> hotels, string travelTo, DateOnly date, int nightstoStay)
            {
               if (flights == null || hotels == null)
                    throw new ArgumentNullException("list is null please check your code ");
              
               IEnumerable<Flight> flightSearchresults = getFlightListForAnyLondonAirport(flights, travelTo, date);
               IEnumerable<Hotel> hotelSearchResults = getHotelList(hotels, travelTo, nightstoStay);
           
            return holidayPackage(flightSearchresults, hotelSearchResults);
        }
        private static IEnumerable<Flight> GetFlightList(List<Flight> flights, string departFrom, string travelTo, DateOnly flightDate)
        {
            //return flights.Where(f => f.from == departFrom && f.to == travelTo && f.departure_date.Equals(flightDate));
            IEnumerable<Flight> flightSearchresults = from flight in flights
                                                      where flight.@from == departFrom && flight.to == travelTo && flight.departure_date.Equals(flightDate)
                                                      orderby flight.price
                                                      select flight;
            return flightSearchresults;
        }
        private static IEnumerable<Flight> GetFlightListForAnyAirport(List<Flight> flights, string travelTo, DateOnly flightDate)
        {
            //return flights.Where(f => f.to == travelTo && f.departure_date.Equals(flightDate));
            IEnumerable<Flight> flightSearchresults = from flight in flights
                                                      where flight.to == travelTo && flight.departure_date.Equals(flightDate)
                                                      orderby flight.price
                                                      select flight;
            return flightSearchresults;
        }
        private static IEnumerable<Flight> getFlightListForAnyLondonAirport(List<Flight> flights, string travelTo, DateOnly flightDate)
        {
            string[] londonAirports = new string[] { "LCY", "LGW", "LHR", "LTN" };
            //  return flights.Where(f => f.from.Contains("L") && f.to == travelTo && f.departure_date.Equals(flightDate));
            IEnumerable<Flight> flightSearchresults = from flight in flights
                                                      where londonAirports.Contains(flight.@from) && flight.to == travelTo && flight.departure_date.Equals(flightDate)
                                                      orderby flight.price
                                                      select flight;
            return flightSearchresults;
        }
        private static IEnumerable<Hotel> getHotelList(List<Hotel> hotels, string travelTo, int nightstoStay)
        {

            //    //getting  the hotel list based on nights
            //IEnumerable<Hotel> hotelSearchResults = hotels.Where(h => h.nights == nightstoStay && h.local_airports.Contains(travelTo))
            //                                                  .OrderBy(h => h.price_per_night);

            //getting  the hotel list based on nights
            IEnumerable<Hotel> hotelSearchResults = from hotel in hotels
                                                    where hotel.nights == nightstoStay && hotel.local_airports.Contains(travelTo)
                                                    orderby hotel.price_per_night
                                                    select hotel;
            return hotelSearchResults;
        }
        private static List<HolidayPackage> holidayPackage(IEnumerable<Flight> flightSearchresults, IEnumerable<Hotel> hotelSearchResults)
        {
            List<HolidayPackage> holidayPackages = new List<HolidayPackage>();

            foreach (Flight flight in flightSearchresults)
            {
                foreach (Hotel hotel in hotelSearchResults)
                {
                    HolidayPackage holidayPackage = new HolidayPackage();
                    holidayPackage.flight = flight;
                    holidayPackage.hotel = hotel;
                    holidayPackages.Add(holidayPackage);
                }
            }
            return holidayPackages;
        }
    }
}
