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
        public TimeSpan GetScheduleTime(int stationTimeNumber)
        {
            string result;
            string arrivalOrDepartureScheduleTime;
            bool condition;
            switch (stationTimeNumber)
            {
                case 1:
                    arrivalOrDepartureScheduleTime = "Arrival";
                    break;
                case 2:
                    arrivalOrDepartureScheduleTime = "Departure";
                    break;
                default:
                    throw new ArgumentException("Station Time Number is invalid", nameof(stationTimeNumber));
            }
            do
            {
                Console.WriteLine($"Input the Schedule Time of {arrivalOrDepartureScheduleTime} (Format: HH:MM): ");
                result = Console.ReadLine();
                condition = _flightValidator.ValidateTimeFormat(result);

                if (condition == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. The input must only be of the given format");
                }
            } while (!condition);
            return TimeSpan.Parse(result);     
        }
    }
}