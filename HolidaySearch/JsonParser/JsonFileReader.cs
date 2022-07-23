using HolidaySearch.Model;
using System.Text.Json;


namespace HolidaySearch.JsonParser
{
    public class JsonFileReader : IJsonFileReader
    {
        public List<Hotel> HotelJsonReader()
        {
            List<Hotel> hotelList = new List<Hotel>();
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new CustomDateOnlyConverter("yyyy-MM-dd"));

            using (StreamReader r = new StreamReader("D:/Learning/OnTheBeachTechTask/OnTheBeach/HolidaySearch/Input/hotel.json"))
            {
                var json = r.ReadToEnd();
                hotelList = System.Text.Json.JsonSerializer.Deserialize<List<Hotel>>(json, options);
            }

            return hotelList;
        }
        public List<Flight> FlightJsonReader()
        {
            List<Flight> flightList = new List<Flight>();
            var options = new JsonSerializerOptions() { WriteIndented = true };
            options.Converters.Add(new CustomDateOnlyConverter("yyyy-MM-dd"));

            using (StreamReader r = new StreamReader("D:/Learning/OnTheBeachTechTask/OnTheBeach/HolidaySearch/Input/flight.json"))
            {
                string json = r.ReadToEnd();
                flightList = System.Text.Json.JsonSerializer.Deserialize<List<Flight>>(json, options);

                return flightList;
            }
        }
    }
}

