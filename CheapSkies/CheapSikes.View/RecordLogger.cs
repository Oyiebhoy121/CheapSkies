using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheapSkies.Controller;
using CheapSkies.Validator;

namespace CheapSkies.View
{
    public class RecordLogger
    {
        protected RecordValidator _recordValidator;
        public RecordLogger(RecordValidator recordValidator)
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
                    Console.Clear();
                    Console.WriteLine("Invalid Input. The input must be 2-3 Uppercased Alphanumberic Code. " +
                        "Numeric Character must only appear once.");
                }
            }   while(!condition);
            return result;
        }

        public string GetFlightNumbers()
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
                    Console.Clear();
                    Console.WriteLine("Invalid Input. The input must be an an integer between 1-9999");
                }
            }   while (!condition);
            return result;
        }

        public string GetStation(int stationNumber)
        {
            string result;
            string arrivalOrDepartureStation;
            bool condition;
            switch (stationNumber)
            {
                case 1:
                    arrivalOrDepartureStation = "Arrival";
                    break;
                case 2:
                    arrivalOrDepartureStation = "Departure";
                    break;
                default:
                    throw new ArgumentException("Station Number is invalid", nameof(stationNumber));
            }
            do
            {
                Console.WriteLine($"Input {arrivalOrDepartureStation} Station (e.g. MNL, AB3, NRT): ");
                result = Console.ReadLine();
                condition = _recordValidator.ValidateStation(result);

                if (condition == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. The input must be exaclty 3 Uppercased Alphanumberic Code. " +
                        "Numeric Characters are optional. First character must be a letter");
                }
            }   while (!condition);
            return result;
        }
    }
}
