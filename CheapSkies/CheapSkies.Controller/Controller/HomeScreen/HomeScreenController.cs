using CheapSkies.Controller.Controller.Flight_Maintenance_Screen;
using CheapSkies.Controller.Controller.Reservation_Screen;
using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller.Home_Screen
{
    public class HomeScreenController
    {
        private readonly string[] menu = 
        {
            "Welcome to CheapSkies! What do you want to do?",
            "Press 1 and Enter => Go to Flight Maintenance Screen",
            "Press 2 and Enter => Go to Reservation Screen",
            "Press 3 and Enter => Exit CheapSkies\n"
        };

        private void Initialize()
        {
            UI ui = new UI();
            //FlightMaintenanceController flightMaintenanceController = new FlightMaintenanceController();
            //SearchFlightController searchFlightController = new SearchFlightController();
        }

        public void DisplayHomeScreen()
        {
            UI ui = new UI();
            string userInput = "";

            while (userInput != "3")
            {
                ui.Display(menu);
                userInput = ui.GetInput();

                switch (userInput)
                {
                    case "1":
                        //flightMaintenanceController
                        break;
                    case "2":
                        //searchFlightController
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
