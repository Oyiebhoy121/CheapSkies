using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.View
{
    public class RecordLogger
    {
        public string InputAirlineCode() 
        {
            Console.WriteLine("Input Airline Code: ");
            string result = Console.ReadLine();
            return result;
        }

        public string InputFlightNumbers()
        {
            Console.WriteLine("Input Flight Number: ");
            string result = Console.ReadLine();
            return result;
        }

        public int InputArrivalStation()
        {
            Console.WriteLine("Input Origin Station: ");
            string result = Console.ReadLine();
            return result;
        }

        public string InputDepartureStation()
        {
            Console.WriteLine("Input Departure Station: ");
            string result = Console.ReadLine();
            return result;
        }
    }
}
