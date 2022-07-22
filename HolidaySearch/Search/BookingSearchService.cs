using HolidaySearch.JsonParser;
using HolidaySearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Search
{
    public class BookingSearchService
    {    
        public IEnumerable<Flight> GetFlightList(List<Flight> flights, string departFrom, string travelTo,string date)
        {
            DateOnly flightDate = DateOnly.Parse(date);
            return flights.Where(f => f.from == departFrom && f.to == travelTo && f.departure_date.Equals(flightDate));
                                                                  
        }
        public IEnumerable<Flight> GetFLightListForAnyAirport(List<Flight> flights, string travelTo, string date)
        {
            DateOnly flightDate = DateOnly.Parse(date);
            return flights.Where(f => f.to == travelTo && f.departure_date.Equals(flightDate));

        }
        public IEnumerable<Flight> GetFLightListForAnyLondonAirport(List<Flight> flights, string travelTo, string date)
        {
            DateOnly flightDate = DateOnly.Parse(date);
            return flights.Where(f => f.from.Contains("L") && f.to == travelTo && f.departure_date.Equals(flightDate));

        }
        public IEnumerable<Hotel> GetHotelList(List<Hotel> hotels, string travelTo, int nightstoStay)
        {
            IEnumerable<Hotel> hotelSearchResults = hotels.Where(h => h.nights == nightstoStay)
                                                                .OrderBy(h => h.price_per_night);
            List<Hotel> hotelList = new List<Hotel>();
            foreach (Hotel hotel in hotelSearchResults)
            {
                foreach (var h in hotel.local_airports)
                {
                    if (h.Equals(travelTo))
                    {
                        hotelList.Add(hotel);
                    }
                }
            }

            return hotelList;
        }
       
      
    }
}
