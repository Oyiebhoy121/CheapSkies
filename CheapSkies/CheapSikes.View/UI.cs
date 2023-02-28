using System.Security.Cryptography;

namespace CheapSkies.View
{
    public class UI 
    {
        public void Clear()
        {
            Console.Clear();
        }
        public void Display(string[] message)
        {
            foreach(string m in message)
            {
                Console.WriteLine(m);
            }
        }
        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public void Display(string message, int number)
        {
            Console.WriteLine(message + number);
        }
        public void Display(string message, string input)
        {
            Console.WriteLine(message + input);
        }
        public void Display(string message, string input1, string input2)
        {
            Console.WriteLine(message + input1 + "-" + input2);
        }

        public void ExitScreen()
        {
            Console.WriteLine("\n\nPress anything to go back Home");
            Console.Read();
        }


        public string GetInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

    

        public string DisplayReservationScreenAndGetInput()
        {
            Console.Clear();
            Console.WriteLine("Reservation Screen");
            Console.WriteLine("Press 1 and enter => Create a Reservation");
            Console.WriteLine("Press 2 and enter => List all Reservations");
            Console.WriteLine("Press 3 and enter => Search Reservation by PNR");
            Console.WriteLine("Press 4 and enter => Go Back to Flight Maintenance Screen");
            string decision = Console.ReadLine();
            return decision;
        }
    }
}
