using CheapSkies.View;

namespace CheapSikes.View
{
    public class FlightLogger : RecordLogger
    {
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