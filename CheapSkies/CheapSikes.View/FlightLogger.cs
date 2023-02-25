using CheapSkies.Controller;
using CheapSkies.Validator;
using CheapSkies.View;

namespace CheapSikes.View
{
    public class FlightLogger : RecordLogger
    {
        private FlightValidator _flightValidator;
        public FlightLogger(FlightValidator flightValidator) : base(flightValidator)
        {
            _flightValidator = flightValidator;
        }

        public string InputScheduleTimeOfArrival()
        {
            Console.WriteLine("Input the Schedule Time of Arrival:");
            string result = Console.ReadLine();
            return result;
        }

        public string InputScheduleTimeOfDeparture()
        {
            Console.WriteLine("Input the Schedule Time of Destination:");
            string result = Console.ReadLine();
            return result;
        }


    }
}