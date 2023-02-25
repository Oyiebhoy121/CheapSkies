using CheapSikes.View;
using CheapSkies.Controller;
using CheapSkies.Model;
using CheapSkies.Validator;
using CheapSkies.View;

namespace CheapSkies
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //FlightValidator flightValidator = new FlightValidator();
            //FlightLogger flightLogger = new FlightLogger(flightValidator);
            //string airlineCode = flightLogger.GetAirlineCode();
            //int flightNumber = flightLogger.GetFlightNumbers();
            //string arrivalStation = flightLogger.GetStation(1);
            //string departureStation = flightLogger.GetStation(2);
            //TimeSpan arrivalTime = flightLogger.GetScheduleTime(1);
            //TimeSpan departureTime = flightLogger.GetScheduleTime(2);
            
            PassengerValidator passengerValidator = new PassengerValidator();
            PassengerLogger passengerLogger = new PassengerLogger(passengerValidator);
            //string firstName = passengerLogger.InputName(1);
            //string lastName = passengerLogger.InputName(2);g
            DateTime birthDay = passengerLogger.InputBirthDate();
            int numberOfPassengers = passengerLogger.InputNumberOfPassenger();

        }
    }
}