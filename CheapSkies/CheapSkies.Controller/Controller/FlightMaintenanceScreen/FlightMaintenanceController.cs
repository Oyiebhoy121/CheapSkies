using CheapSkies.Controller.Controller.Flight_Maintenance_Screen;
using CheapSkies.Controller.Validators;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller
{
    public class FlightMaintenanceController
    {
        private readonly string[] menu =
        {
            "Flight Maintenance Screen",
            "Press 1 and Enter => Add a Flight",
            "Press 2 and Enter => Search a Flight",
            "Press 3 and Enter => Go Back to Home Screen\n"
        };

        public void DisplayFlightMaintenanceScreen()
        {
            UI ui = new UI();
            AddFlightController addFlightController = new AddFlightController();
            string userInput = "";

            while(userInput != "1" || userInput != "2" || userInput != "3")
            {
                ui.Display(menu);
                userInput = ui.GetInput();

                switch(userInput)
                {
                    case "1":
                        addFlightController.AddFlight();
                        break;
                    case "2":
                        //SearchFlight
                        break;
                    case "3":
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
