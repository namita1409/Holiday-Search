using NUnit.Framework;
using HolidaySearch.JsonParser;
namespace HolidaySearchTest
{
    public class Tests
    {
        private  JsonFileReader _JsonFileReadr;
        [SetUp]
        public void Setup()
        {
            _JsonFileReadr = new JsonFileReader();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}