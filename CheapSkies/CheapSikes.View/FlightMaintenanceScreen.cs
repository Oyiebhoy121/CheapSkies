using CheapSikes.View;
using CheapSkies.Controller;
using CheapSkies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.View
{
    public class FlightMaintenanceScreen
    {
        private FlightLogger _flightLogger;
        public FlightMaintenanceScreen(FlightLogger flightLogger)
        {
            _flightLogger = flightLogger;
        }
        public void GetFlightMaintenanceScreen()
        {
            Console.WriteLine("Flight Maintenance Screen");
            Console.WriteLine("Press 1 and enter => Add a Flight");
            Console.WriteLine("Press 2 and enter => Search a Flight");
            Console.WriteLine("Press 3 and enter => Go Back\n");
            string decision = Console.ReadLine();

            switch (decision)
            {
                case "1":
                    AddFlight();
                    break;
                case "2":
                    SearchFlight();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please choose between 1, 2, and 3 only");
                    break;
            }
        }
        public void AddFlight()
        {
            Console.Clear();
            Console.WriteLine("Adding a Flight\n");
            string airlineCode = _flightLogger.GetAirlineCode();
            int flightNumber = _flightLogger.GetFlightNumbers();
            string arrivalStation = _flightLogger.GetStation(1);
            string departureStation = _flightLogger.GetStation(2);
            TimeSpan scheduleTimeOfArrival = _flightLogger.GetScheduleTime(1);
            TimeSpan scheduleTimeOfDeparture = _flightLogger.GetScheduleTime(2);

            Flight flight = new Flight(airlineCode, flightNumber, arrivalStation, departureStation, 
                scheduleTimeOfArrival, scheduleTimeOfDeparture);
        }

        public void SearchFlight()
        {
            Console.Clear();
            Console.WriteLine("Search Flight Screen");
            Console.WriteLine("Press 1 and enter => Search by Flight Number");
            Console.WriteLine("Press 2 and enter => Search by Airline Code");
            Console.WriteLine("Press 3 and enter => Search by Origin and Departure Station");
            Console.WriteLine("Press 4 and enter => Go Back");
            string decision = Console.ReadLine();

            switch (decision)
            {
                case "1":
                    
                    break;
                case "2":
                    
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please choose between 1, 2, 3, and 4 only");
                    break;
            }

        }
    }
}
