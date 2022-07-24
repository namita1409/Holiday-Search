using HolidaySearch.Model;
using System.Text.Json;

namespace HolidaySearch.JsonParser
{
    public class JsonFileParser : IJsonFileParser
    {
        public List<Hotel> GetHotelsFromJsonFile(string fileName)
        {            
            using (StreamReader r = new StreamReader(fileName))
            {
                string jsonString = r.ReadToEnd();
                return ParseHotelJsonString(jsonString);
            }
        }
        public List<Hotel> ParseHotelJsonString(string jsonString)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new CustomDateOnlyConverter("yyyy-MM-dd"));
            return JsonSerializer.Deserialize<List<Hotel>>(jsonString, options);
        }
        public List<Flight> GetFlightsFromJsonFile(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {                
                string jsonString = r.ReadToEnd();
                return ParseFlightJsonString(jsonString);                
            }            
        }
        public  List<Flight> ParseFlightJsonString(string jsonString)
        {           
            var options = new JsonSerializerOptions() { WriteIndented = true };
            options.Converters.Add(new CustomDateOnlyConverter("yyyy-MM-dd"));
            return JsonSerializer.Deserialize<List<Flight>>(jsonString, options);
        }
    }
}

