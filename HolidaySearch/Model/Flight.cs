using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Model
{
    public class Flight
    {
        public int id { get; set; }
        public string airline { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public long price { get; set; }
        public DateOnly departure_date { get; set; }

        public string toString()
        {
            return "Id: " + id + "\n"
                + "airline: " + airline + "\n"
                + "from: " + from + "\n"
                + "to: " + to + "\n"
                + "price: " + price + "\n"
                + "departure_date: " + departure_date;
        }

    }
}
