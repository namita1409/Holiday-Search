using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Model
{
    public class Hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateOnly arrival_date { get; set; }
        public int price_per_night { get; set; }         
        public List<string> local_airports { get; set; }

        public int nights { get; set; }

        public string toString() 
        {
            return "Id: " + id +"\n"
                + "Name: " + name + "\n"
                + "ArrivalDate: " + arrival_date + "\n"
                + "PricePerNight: " + price_per_night + "\n"
                + "Nights: " + nights+"\n"
                +"Airport: "+local_airports.First();
        }
    }
}
