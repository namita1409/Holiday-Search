using HolidaySearch.Model;
using HolidaySearch.Search;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchTest
{
    public class SearchTest
    {
        private BookingSearchService _Search;

        [SetUp]
        public void Setup()
        {
            _Search = new BookingSearchService();
        }

        [Test]
        public void Test1()
        {
            //arrange


            //act

            //assert

        }
        /*  private List<Flight> GetFakeFlight() 
          {
              return new List<Flight>
              {
                  new Flight
                  {
                      id = 2,
                      airline = "Oceanic Airlines",
                      from = "MAN",
                      to = "AGP",
                      price = 245,
                      departure_date = 2023-07-01
                  }
              };
          }*/
    }
}
