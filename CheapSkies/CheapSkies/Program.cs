using CheapSikes.View;
using CheapSkies.Controller;
using CheapSkies.Model;
using CheapSkies.Validator;
using CheapSkies.View;
using System.Security.Cryptography.X509Certificates;

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

            //PassengerValidator passengerValidator = new PassengerValidator();
            //PassengerLogger passengerLogger = new PassengerLogger(passengerValidator);
            //string firstName = passengerLogger.InputName(1);
            //string lastName = passengerLogger.InputName(2);
            //DateTime birthDay = passengerLogger.InputBirthDate();



            List<string> listOfString = new List<string>()
            {
                "P43R23"
            };

            DateTime dateTime = DateTime.Now;
            Reservation reservation = new Reservation("5J", 12, "MNL", "CEB", dateTime, 3, listOfString);

            Console.WriteLine(reservation.PNR);

        }
    }
}