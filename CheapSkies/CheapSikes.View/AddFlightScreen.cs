namespace CheapSkies.View
{
    public class AddFlightScreen : GeneralRecordScreen
    {
        public string AskForFlightNumbereAndGetInput()
        {
            throw new NotImplementedException();
        }

        public string AskForScheduleTimeAndGetInput(string arrivalOrDepartureScheduleTime)
        {
            Console.WriteLine("Input the Schedule Time of {arrivalOrDepartureScheduleTime} (Format: HH:MM): ");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayAddFlightScreen()
        {
            Console.Clear();
            Console.WriteLine("Adding Flight\n");
        }

        public void DisplayInvalidScheduleTimeMessage()
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