namespace CheapSkies.View
{
    public class CreateReservationScreen : GeneralRecordScreen
    {
        public string AskForFlightDateAndGetInput()
        {
            Console.WriteLine("Input the Flight Date (Format: mm/dd/yyy)");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayInvalidFlightDateMessage()
        {
            Console.WriteLine("Invalid Input. Follow the given format. Make sure that the date is not a past date");
        }

        public string AskForNumberOfPassengersAndGetInput()
        {
            Console.WriteLine("Input the number of passengers you are booking (1-5 passengers only):  ");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayInvalidNumberOfPassengersMessage()
        {
            Console.Clear();
            Console.WriteLine("Invalid Input. Please select a number from 1 to 5 only");
        }

        public void DisplayCreateReservationMessage()
        {
            Console.Clear();
            Console.WriteLine("Creating Reservation\n");
        }

        public void DisplaySuccessfullyCreatedReservation()
        {
            Console.WriteLine("Successfully Created a Reservation\n");
            Console.WriteLine("Press any key to go back Home");
            Console.Read();
        }



    }
}
