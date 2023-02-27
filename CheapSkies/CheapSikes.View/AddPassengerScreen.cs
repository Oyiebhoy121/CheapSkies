namespace CheapSkies.View
{
    public class AddPassengerScreen
    {
        public string AskForNameAndGetInput(string firstOrLastName)
        {
            Console.WriteLine($"Input the {firstOrLastName} Name of the Passenger (e.g. John, Smith): ");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayInvalidName()
        {
            Console.Clear();
            Console.WriteLine("Invalid Input. The input must be composed of 1-20 Characters only. " +
                "Letters and spaces only.");
        }

        public string AskForBirthDateAndGetInput()
        {
            Console.WriteLine("Input Passenger's BirthDate (Format: mm/dd/yyyy): ");
            string result = Console.ReadLine();
            return result;
        }

        public void DisplayInvalidBirthDate()
        {
            Console.Clear();
            Console.WriteLine("Invalid Input. Follow the given format. Make sure that the date is not a future date");
        }

        public void AskForPassengerInfo(int passengerNumber)
        {
            Console.Clear();
            Console.WriteLine($"Please input the information of Passenger No.{passengerNumber + 1}");
        }
        public void DisplaySuccessfullyAddedPassengers()
        {
            Console.Clear();
            Console.WriteLine("Passengers added Successfully!");
        }

        public void DisplayAddPassengerMessage()
        {
            Console.Clear();
            Console.WriteLine("Adding Passengers\n");
        }
             
      
    }
}
