
using HolidaySearch.Model;

namespace HolidaySearch.Search
{
    public class BookingSearchService
    {

        public IEnumerable<HolidayPackage> GetFlightHotelList(List<Flight> flights, List<Hotel> hotels, string departFrom, string travelTo, string date, int nightstoStay)
        {
            if (flights == null || hotels==null)
                throw new ArgumentNullException("list is null ");           

                DateOnly flightDate = DateOnly.Parse(date);
                IEnumerable<Flight> flightSearchresults = GetFlightList(flights, departFrom, travelTo, flightDate);
                IEnumerable<Hotel> hotelSearchResults = GetHotelList(hotels, travelTo, nightstoStay);
                return holidayPackage(flightSearchresults, hotelSearchResults);
            
        }
        public IEnumerable<HolidayPackage> GetFlightHotelListForAnyAirport(List<Flight> flights, List<Hotel> hotels, string travelTo, string date, int nightstoStay)
        {
            if (flights == null || hotels == null)
                throw new ArgumentNullException("list is null ");

            DateOnly flightDate = DateOnly.Parse(date);
            IEnumerable<Flight> flightSearchresults = GetFlightListForAnyAirport(flights, travelTo, flightDate);

            IEnumerable<Hotel> hotelSearchResults = GetHotelList(hotels, travelTo, nightstoStay);

            // List<HolidayPackage> holidayPackages = compileHolidayPackage(flightSearchresults, hotelSearchResults);
            return holidayPackage(flightSearchresults, hotelSearchResults); 
        }
        public IEnumerable<HolidayPackage> GetFlightHotelListForAnyLondonAirport(List<Flight> flights, List<Hotel> hotels, string travelTo, string date, int nightstoStay)
        {
            if (flights == null || hotels == null)
                throw new ArgumentNullException("list is null ");

            DateOnly flightDate = DateOnly.Parse(date);
            IEnumerable<Flight> flightSearchresults = GetFlightListForAnyLondonAirport(flights, travelTo, flightDate);

            IEnumerable<Hotel> hotelSearchResults = GetHotelList(hotels, travelTo, nightstoStay);

           // List<HolidayPackage> holidayPackages = compileHolidayPackage(flightSearchresults, hotelSearchResults);
            return holidayPackage(flightSearchresults, hotelSearchResults); ;

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
        private static IEnumerable<Flight> GetFlightListForAnyLondonAirport(List<Flight> flights, string travelTo, DateOnly flightDate)
        {
            string[] londonAirports = new string[] { "LCY", "LGW", "LHR", "LTN" };
            //  return flights.Where(f => f.from.Contains("L") && f.to == travelTo && f.departure_date.Equals(flightDate));
            IEnumerable<Flight> flightSearchresults = from flight in flights
                                                      where londonAirports.Contains(flight.@from) && flight.to == travelTo && flight.departure_date.Equals(flightDate)
                                                      orderby flight.price
                                                      select flight;
            return flightSearchresults;
        }
        private static IEnumerable<Hotel> GetHotelList(List<Hotel> hotels, string travelTo, int nightstoStay)
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
