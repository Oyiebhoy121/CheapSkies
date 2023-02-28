using CheapSkies.Controller.Controller.Flight_Maintenance_Screen;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller
{
    public class FlightMaintenanceController : IFlightMaintenanceController
    {
        private UI _ui = new UI();

        private readonly string[] menu =
        {
            "Flight Maintenance Screen",
            "Press 1 and Enter => Add a Flight",
            "Press 2 and Enter => Search a Flight",
            "Press 3 and Enter => Go Back to Home Screen\n"
        };

        public void DisplayFlightMaintenanceScreen()
        {
            AddFlightController addFlightController = new AddFlightController();
            SearchFlightController searchFlightController = new SearchFlightController();
            string userInput = "";

            while(userInput != "1" || userInput != "2" || userInput != "3")
            {
                _ui.Clear();
                _ui.Display(menu);
                userInput = _ui.GetInput();

                switch(userInput)
                {
                    case "1":
                        addFlightController.AddFlight();
                        return;
                    case "2":
                        searchFlightController.SearchFlight();
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
