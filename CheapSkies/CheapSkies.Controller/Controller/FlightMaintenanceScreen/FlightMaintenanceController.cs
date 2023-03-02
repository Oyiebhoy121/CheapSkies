using CheapSkies.Controller.Controller.Interface.FlightMaintenancScreen.Interface;
using CheapSkies.View.View.Interface;

namespace CheapSkies.Controller.Controller
{
    public class FlightMaintenanceController : IFlightMaintenanceController
    {
        private readonly IAddFlightController _addFlightController;
        private readonly ISearchFlightController _searchFlightController;
        private readonly IUserInterface _userInterface;

        private readonly string[] menu =
        {
            "Flight Maintenance Screen",
            "Press 1 and Enter => Add a Flight",
            "Press 2 and Enter => Search a Flight",
            "Press 3 and Enter => Go Back to Home Screen\n"
        };

        public FlightMaintenanceController(IAddFlightController addFlightController, ISearchFlightController searchFlightController, IUserInterface userInterface)
        {
            _addFlightController = addFlightController;
            _searchFlightController = searchFlightController;
            _userInterface = userInterface;
        }

        /// <summary>
        /// Opens the Flight Maintenance Screen. This will prompt the user to choose between Adding Flight, Searching for Flight, or going 
        /// back to the Home Screen. This will run until the user inputted a valid option
        /// </summary>
        public void DisplayFlightMaintenanceScreen()
        {
            string userInput = "";

            while(userInput != "1" || userInput != "2" || userInput != "3")
            {
                _userInterface.Clear();
                _userInterface.Display(menu);
                userInput = _userInterface.GetInput();

                switch(userInput)
                {
                    case "1":
                        _addFlightController.AddFlight();
                        return;
                    case "2":
                        _searchFlightController.SearchFlight();
                        return;
                    case "3":
                        return;
                    default:
                        break;
                }
            }
        }

    }
}
