using CheapSkies.Controller.Controller.Interface.FlightMaintenancScreen.Interface;
using CheapSkies.View.View;
using CheapSkies.View.View.Interface;

namespace CheapSkies.Controller.Controller.Flight_Maintenance_Screen
{
    public class SearchFlightController : ISearchFlightController
    {
        private IUserInterface _userInterface = new UserInterface();
        private IDisplayFlightController _displayFlightController;

        private readonly string[] menu =
        {
            "Search Flight Screen",
            "Press 1 and enter => Search by Flight Number",
            "Press 2 and enter => Search by Airline Code",
            "Press 3 and enter => Search by Origin and Departure Station",
            "Press 4 and enter => Go Back to Flight Maintenance Screen"
        };

        public SearchFlightController(IDisplayFlightController displayFlightController, IUserInterface userInterface)
        {
            _displayFlightController = displayFlightController;
            _userInterface = userInterface;
        }

        /// <summary>
        /// Opens Search Flight Screen. This will prompt the user to choose between Searching Flights 
        /// via Flight Number, via Airline Code, Via Stations, or just going back to the Flight Maintenance Screen.
        /// This will run until the user inputted a valid option.
        /// </summary>
        public void SearchFlight()
        {
            string userInput = "";

            while (userInput != "1" || userInput != "2" || userInput != "3")
            {
                _userInterface.Clear();
                _userInterface.Display(menu);
                userInput = _userInterface.GetInput();

                switch (userInput)
                { 
                    case "1":
                        _displayFlightController.DisplayFlightbyFlightNumber();
                        return; 
                    case "2":
                        _displayFlightController.DisplayFlightByAirlineCode();
                        return;
                    case "3":
                        _displayFlightController.DisplayFlightByStations();
                        return;
                    case "4":
                        return;
                    default:
                        break;
                }
            }
        }
        
    }
}
