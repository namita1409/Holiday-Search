## Holiday Search
`This is a standard Console-based application which allows user to read two Json files and display output as per user
requests.

Below is the prjoect folder structure summary:

1. The `HolidaySearch` folder contains the C# solution to the application
2. The `HolidaySearchTest` folder contains the unit tests for the solution

# Business requirement
👉 Your application should read from the provided `hotel.json` and `flight.json` file

The `hotel.json` contains data required to book the hotel:

● id

● name

● arrival_date

● price_per_night

● nights

The `flight.json` contains data required to book the flight:

● id

● airline

● from

● to

● price

● departure_date


# User Story

👉 Taking the two JSON files of flights and hotels as source data, please create a small library of code that provides a basic holiday search feature.

👉 Here’s the list of criteria your program must be able to output according to the user
requests:


 🏚The first search result should be the best value holiday (best price) we can provide, based on the customers requirements.
 
 👉 Sample test cases to verify the success of work are listed below:
 
 ## Acceptance criteria
 ### Customer #1

##### Input
 * Departing from: Manchester Airport (MAN)
 * Travelling to: Malaga Airport (AGP)
 * Departure Date: 2023/07/01
 * Duration: 7 nights

##### Expected result  
 * Flight 2 and Hotel 9

### Customer #2

##### Input
 * Departing from: Any London Airport
 * Travelling to: Mallorca Airport (PMI)
 * Departure Date: 2023/06/15
 * Duration: 10 nights

##### Expected result  
 * Flight 6 and Hotel 5

### Customer #3

##### Input
 * Departing from: Any Airport
 * Travelling to: Gran Canaria Airport (LPA)
 * Departure Date: 2022/11/10
 * Duration: 14 nights

##### Expected result  
 * Flight 7 and Hotel 6

# Prerequisite for this project
C#

# Instructions

The machine running the application should have [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) (or above) installed.

Clone the repository to your computer.

Then run the command:

```
dotnet publish -o outputdir
cp .\Input\flight.json .\outputdir\.
cp .\Input\hotel.json .\outputdir\.
cp .\Input\blank.json .\outputdir\.
cp .\Input\invalidData.json .\outputdir\.

```
Now run the test

```
dotnet test -v d .\outputdir\HolidaySearchTest.dll

```
To run the application:

```
dotnet run 
```
 ## Test Case Files
 
`HolidaySearchServiceTestWithFile.cs` - Test file for `HolidaySearchService.cs` with JSON file data

`HolidaySearchServiceTestWithMockData.cs` - Test file for `HoliaySearchSevice.cs` with mock Hotel and Flight data

`JsonFileParserTest` - Test file for `JsonFileParser.cs`

