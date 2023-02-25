using CheapSkies.Model;
using CheapSkies.Validator;
using CheapSkies.View;

namespace CheapSkies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RecordValidator recordValidator = new RecordValidator();
            RecordLogger recordLogger = new RecordLogger(recordValidator);
            string airlineCode = recordLogger.GetAirlineCode();
            string flightNumber = recordLogger.GetFlightNumbers();
            string arrivalStation = recordLogger.GetStation(1);
            string departureStation = recordLogger.GetStation(2);
            Console.WriteLine(airlineCode);
        }
    }
}