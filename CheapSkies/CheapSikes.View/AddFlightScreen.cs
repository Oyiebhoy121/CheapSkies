using CheapSkies.Controller;
using CheapSkies.Validator;
using CheapSkies.View;

namespace CheapSikes.View
{
    public class AddFlightScreen : GeneralRecordScreen
    {
        public string AskForScheduleTimeAndGetInput(string arrivalOrDepartureScheduleTime)
        {
            Console.WriteLine("Input the Schedule Time of {arrivalOrDepartureScheduleTime} (Format: HH:MM): ");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayInvalidScheduleTime()
        {
            Console.Clear();
            Console.WriteLine("Invalid Input. The input must only be of the given format");
        }

        public void DisplaySuccessfullyAddedFlight()
        {
            Console.Clear();
            Console.WriteLine("Flight added Successfully!");
            Console.WriteLine("Press any key to go back Home");
            Console.Read();
        }
    }
}