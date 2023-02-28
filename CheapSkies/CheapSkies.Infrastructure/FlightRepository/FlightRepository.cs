using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using Interfaces;
using System;
using System.IO;
using System.Linq;

namespace CheapSkies.Infrastructure
{
    public class FlightRepository 
    {
        private string _filePath = "C:\\Users\\fgoleta\\Desktop\\CheapSkies\\CheapSkies\\CheapSkies.Infrastructure\\FlightRepository\\FlightRepository.txt";

        public void SaveFlight(Flight flight)
        {
            string flightProperties = String.Join(", ", flight.AirlineCode, flight.FlightNumber, flight.ArrivalStation, flight.DepartureStation, flight.ScheduleTimeOfArrival, flight.ScheduleTimeOfDeparture);
            
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(_filePath, append: true))
                {
                    streamWriter.WriteLine(flightProperties);
                }
            }
            catch
            {
                Console.WriteLine("Failed to save the flight because Saving File Path is not found. Change it first.");
            }
        }
        public List<FlightBase> GetFlightData() //Get All Flight Data
        {
            List<FlightBase> listOfFlights = new List<FlightBase>();

            try
            {
                using (StreamReader streamReader = new StreamReader(_filePath))       
                {
                    string textLines;
                    while ((textLines = streamReader.ReadLine()) != null)
                    {
                        string[] flightProperties = textLines.Split(", ");
                        FlightBase flight = new FlightBase()
                        {
                            AirlineCode = flightProperties[0],
                            FlightNumber = Int32.Parse(flightProperties[1]),
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

        public List<FlightBase> GetFlightData(int flightNumber) //Get Flight Data via Flight Number
        {
            List<FlightBase> listOfFlight = GetFlightData();
  
            return listOfFlight.Where(flight => flight.FlightNumber == flightNumber).ToList();
        }

        public List<FlightBase> GetFlightData(string airlineCode) //Get Flight Data via Airline Code
        {
            List<FlightBase> listOfFlight = GetFlightData();

            return listOfFlight.Where(flight => flight.AirlineCode == airlineCode).ToList();
        }

        public List<FlightBase> GetFlightData(string arrivalStation, string departureStation) //Get Flight Data via Stations
        {
            List<FlightBase> listOfFlight = GetFlightData();

            return listOfFlight.Where(flight => flight.ArrivalStation == arrivalStation
                                                    && flight.DepartureStation == departureStation).ToList();
        }
    }
}