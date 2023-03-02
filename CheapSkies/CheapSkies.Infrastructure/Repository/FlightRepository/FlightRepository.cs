using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;

namespace CheapSkies.Infrastructure.Repository.FlightRepository
{
    public class FlightRepository : IFlightRepository
    {
        private const string FilePath = "C:\\Users\\fgoleta\\Desktop\\CheapSkies\\CheapSkies\\CheapSkies.Infrastructure\\Repository\\FlightRepository\\FlightRepository.txt";

        /// <summary>
        /// Saves an inputted validated Flight properties to the FlightRepository.txt file
        /// as a series of comma-separated strings. This will throw an Exception if the 
        /// File Path specified to PassengerRepository.txt is non-existant
        /// </summary>
        /// <param name="flight">Inputted Validated Flight object by the user</param>
        public void SaveFlight(Flight flight)
        {
            string flightProperties = string.Join(", ", flight.AirlineCode, flight.FlightNumber, flight.ArrivalStation, flight.DepartureStation, flight.ScheduleTimeOfArrival, flight.ScheduleTimeOfDeparture);

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(FilePath, append: true))
                {
                    streamWriter.WriteLine(flightProperties);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.WriteLine("Failed to save the flight because Saving File Path is not found. Change it first.");
            }
        }

        /// <summary>
        /// Obtains all the the data from the FlightRepository.txt and then 
        /// refactors the data as properties of FlightBase Model. 
        /// This will throw an Exception if the 
        /// File Path specified to FlightRepository.txt is non-existant
        /// </summary>
        /// <returns>List of All the Flights in the Flight Repository</returns>
        public List<FlightBase> GetFlightData()
        {
            List<FlightBase> listOfFlights = new List<FlightBase>();

            try
            {
                using (StreamReader streamReader = new StreamReader(FilePath))
                {
                    string textLines;
                    while ((textLines = streamReader.ReadLine()) != null)
                    {
                        string[] flightProperties = textLines.Split(", ");

                        FlightBase flight = new FlightBase()
                        {
                            AirlineCode = flightProperties[0],
                            FlightNumber = int.Parse(flightProperties[1]),
                            ArrivalStation = flightProperties[2],
                            DepartureStation = flightProperties[3],
                            ScheduleTimeOfArrival = flightProperties[4],
                            ScheduleTimeOfDeparture = flightProperties[5]
                        };

                        listOfFlights.Add(flight);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Failed to read the flights because File Path is not found. Change it first.");
            }

            return listOfFlights;
        }

        /// <summary>
        /// Obtains all the the data from the FlightRepository.txt that corresponds to the inputted 
        /// flightNumber and refactors the data as properties of FlightBase Model. 
        /// This will throw an Exception if the File Path specified to FlightRepository.txt is non-existant
        /// </summary>
        /// <param name="flightNumber">Inputted FlightNumber by the user as a Search Key</param>
        /// <returns>List of All the Flights in the Flight Repository that matches with flightNumber parameter</returns>
        public List<FlightBase> GetFlightData(int flightNumber)
        {
            List<FlightBase> listOfFlight = GetFlightData();

            return listOfFlight.Where(flight => flight.FlightNumber == flightNumber).ToList();
        }

        /// <summary>
        /// Obtains all the the data from the FlightRepository.txt that corresponds to the inputted 
        /// airlineCode and refactors the data as properties of FlightBase Model. 
        /// This will throw an Exception if the File Path specified to FlightRepository.txt is non-existant
        /// </summary>
        /// <param name="airlineCode">Inputted Airline Code by the user as a Search Key</param>
        /// <returns>List of All the Flights in the Flight Repository that matches with airlineCode parameter</returns>
        public List<FlightBase> GetFlightData(string airlineCode)
        {
            List<FlightBase> listOfFlight = GetFlightData();

            return listOfFlight.Where(flight => flight.AirlineCode == airlineCode).ToList();
        }

        /// <summary>
        /// Obtains all the the data from the FlightRepository.txt that corresponds to the inputted 
        /// Arrival Station and Departures Station and refactors the data as properties of FlightBase Model. 
        /// This will throw an Exception if the File Path specified to FlightRepository.txt is non-existant
        /// </summary>
        /// <param name="arrivalStation">Inputted Arrival Station Code by the user as a Search Key</param>
        /// <param name="departureStation">Inputted Departure Station Code by the user as a Search Key</param>
        /// <returns>List of All the Flights in the Flight Repository that matches with both the Arrival and Departure Station parameter</returns>
        public List<FlightBase> GetFlightData(string arrivalStation, string departureStation)
        {
            List<FlightBase> listOfFlight = GetFlightData();

            return listOfFlight.Where(flight => flight.ArrivalStation == arrivalStation &&
                flight.DepartureStation == departureStation).ToList();
        }
    }
}