using CheapSkies.Controller.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller
{
    public class FlightController
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
      
            do
            {

                result = Console.ReadLine();
                condition = _flightValidator.ValidateTimeFormat(result);

                if (condition == false)
                {
                    Console.Clear();
                    
                }
            } while (!condition);
            return TimeSpan.Parse(result);
        }
    }
}
