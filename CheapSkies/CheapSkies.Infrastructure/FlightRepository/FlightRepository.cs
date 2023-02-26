using CheapSkies.Interfaces;
using CheapSkies.Model;
using Interfaces;
using System;
using System.IO;
using System.Linq;

namespace CheapSkies.Infrastructure
{
    public class FlightRepository 
    {
        private string _filePath =
            "C:\\Users\\frgol\\OneDrive\\Desktop\\CheapSkies\\CheapSkies\\CheapSkies.Infrastructure\\FlightRepository\\FlightRepository.txt";

        public void SaveFlight(Flight flight)
        {
            string flightProperties = String.Join(", ", flight.AirlineCode, flight.FlightNumber, flight.ArrivalStation,
                                                    flight.DepartureStation, flight.ScheduleTimeOfArrival, flight.ScheduleTimeOfDeparture);
            
            using (StreamWriter streamWriter = new StreamWriter(_filePath, append: true))
            {
                streamWriter.Write(flightProperties);
            }
        }

        public List<Flight> GetFlightData() //Get All Flight Data
        {
            List<Flight> listOfFlights = new List<Flight>();

            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                string textLines;
                while ((textLines = streamReader.ReadLine()) != null)
                {
                    string[] flightProperties = textLines.Split(", ");
                    Flight flight = new Flight()
                    {
                        AirlineCode = flightProperties[0],
                        FlightNumber = Int32.Parse(flightProperties[1]),
                        ArrivalStation = flightProperties[2],
                        DepartureStation = flightProperties[3],
                        ScheduleTimeOfArrival = TimeSpan.Parse(flightProperties[4]),
                        ScheduleTimeOfDeparture = TimeSpan.Parse(flightProperties[5])
                    };
                    listOfFlights.Add(flight);
                }
            }
            return listOfFlights;
        }

        public List<Flight> GetFlightData(int flightNumber) //Get Flight Data via Flight Number
        {
            List<Flight> listOfFlight = GetFlightData();
  
            return listOfFlight.Where(flight => flight.FlightNumber == flightNumber).ToList();
        }

        public List<Flight> GetFlightData(string airlineCode) //Get Flight Data via Airline Code
        {
            List<Flight> listOfFlight = GetFlightData();

            return listOfFlight.Where(flight => flight.AirlineCode == airlineCode).ToList();
        }

        public List<Flight> GetFlightData(string arrivalStation, string departureStation) //Get Flight Data via Stations
        {
            List<Flight> listOfFlight = GetFlightData();

            return listOfFlight.Where(flight => flight.ArrivalStation == arrivalStation
                                                    && flight.DepartureStation == departureStation).ToList();
        }
    }
}