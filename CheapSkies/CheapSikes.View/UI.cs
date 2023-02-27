namespace CheapSkies.View
{
    public class UI 
    {
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

        public void Clear()
        {
            Console.Clear();
        }

        public string GetInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

      
        public string DisplaySearchFlightScreenAndGetInput()
        {
            Console.Clear();
            
            string decision = Console.ReadLine();
            return decision;
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
