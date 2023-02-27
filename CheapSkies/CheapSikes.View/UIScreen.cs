namespace CheapSkies.View
{
    public class UIScreen 
    {
        public string DisplayHomeScreenAndGetInput()
        {
            Console.Clear();
            Console.WriteLine("Welcome to CheapSkies! What do you want to do?");
            Console.WriteLine("Press 1 and Enter => Go to Flight Maintenance Screen");
            Console.WriteLine("Press 2 and Enter => Go to Reservation Screen");
            Console.WriteLine("Press 3 and Enter => Exit CheapSkies\n");
            string userInput = Console.ReadLine();
            return userInput;
        }

        public string DisplayFlightMaintenanceScreenAndGetInput()
        {
            Console.Clear();
            Console.WriteLine("Flight Maintenance Screen");
            Console.WriteLine("Press 1 and Enter => Add a Flight");
            Console.WriteLine("Press 2 and Enter => Search a Flight");
            Console.WriteLine("Press 3 and Enter => Go Back to Home Screen\n");
            string decision = Console.ReadLine();
            return decision;
        }

        public string DisplaySearchFlightScreenAndGetInput()
        {
            Console.Clear();
            Console.WriteLine("Search Flight Screen");
            Console.WriteLine("Press 1 and enter => Search by Flight Number");
            Console.WriteLine("Press 2 and enter => Search by Airline Code");
            Console.WriteLine("Press 3 and enter => Search by Origin and Departure Station");
            Console.WriteLine("Press 4 and enter => Go Back to Flight Maintenance Screen");
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
