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

            FlightValidator flightValidator = new FlightValidator();
            FlightLogger flightLogger = new FlightLogger(flightValidator);
            FlightMaintenanceScreen screen = new FlightMaintenanceScreen(flightLogger);
            screen.GetFlightMaintenanceScreen();

        }
    }
}