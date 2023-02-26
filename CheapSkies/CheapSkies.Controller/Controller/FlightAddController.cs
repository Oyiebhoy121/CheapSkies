using CheapSikes.View;
using CheapSkies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller
{
    public class FlightAddController
    {
        private FlightLogger _flightLogger;
        public FlightAddController(FlightLogger flightLogger)
        { 
            _flightLogger = flightLogger;
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
    }
}
