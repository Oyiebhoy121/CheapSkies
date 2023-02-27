using CheapSkies.Controller.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller
{
    public class RecordController
    {
        protected RecordValidator _recordValidator;
        public RecordController(RecordValidator recordValidator)
        {
            _recordValidator = recordValidator;
        }
        public string GetAirlineCode()
        {
            string result;
            bool condition;
            do
            {
                Console.WriteLine("Input the Airline Code (e.g. 5J, TAM, A4C): ");
                result = Console.ReadLine();
                condition = _recordValidator.ValidateAirlineCode(result);

                if (condition == false)
                {
                    
                }
            } while (!condition);
            return result;
        }

        public int GetFlightNumbers()
        {
            string result;
            bool condition;
            do
            {
                Console.WriteLine("Input Flight Number (e.g. 1, 124, 9999): ");
                result = Console.ReadLine();
                condition = _recordValidator.ValidateFlightNumber(result);

                if (condition == false)
                {
                    
                }
            } while (!condition);
            return Int32.Parse(result);
        }

        public string GetStation(string station)
        {
            string result;
            string arrivalOrDepartureStation = station;
            bool condition;
       
            do
            {
                Console.WriteLine($"Input {arrivalOrDepartureStation} Station (e.g. MNL, AB3, NRT): ");
                result = Console.ReadLine();
                condition = _recordValidator.ValidateStation(result);

                if (condition == false)
                {
                    
                }
            } while (!condition);
            return result;
        }
    }
}

