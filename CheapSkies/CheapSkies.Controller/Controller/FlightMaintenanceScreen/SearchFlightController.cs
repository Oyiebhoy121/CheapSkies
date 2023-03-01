using CheapSkies.Controller.Controller.FlightMaintenanceScreen;
using CheapSkies.Controller.Controller.Interface.FlightMaintenancScreen.Interface;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller.Flight_Maintenance_Screen
{
    public class SearchFlightController : ISearchFlightController
    {
        private UI _ui = new UI();
        private readonly string[] menu =
        {
            "Search Flight Screen",
            "Press 1 and enter => Search by Flight Number",
            "Press 2 and enter => Search by Airline Code",
            "Press 3 and enter => Search by Origin and Departure Station",
            "Press 4 and enter => Go Back to Flight Maintenance Screen"
        };
        public void SearchFlight()
        {
            DisplayFlightController displayFlightController = new DisplayFlightController();
            
            string userInput = "";

            while (userInput != "1" || userInput != "2" || userInput != "3")
            {
                _ui.Clear();
                _ui.Display(menu);
                userInput = _ui.GetInput();

                switch (userInput)
                { 
                    case "1":
                        displayFlightController.DisplayFlightbyFlightNumber();
                        return; 
                    case "2":
                        displayFlightController.DisplayFlightByAirlineCode();
                        return;
                    case "3":
                        displayFlightController.DisplayFlightByStations();
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
