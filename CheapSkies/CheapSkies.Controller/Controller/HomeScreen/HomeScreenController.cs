using CheapSkies.Controller.Controller.Interface.FlightMaintenancScreen.Interface;
using CheapSkies.Controller.Controller.Interface.HomeScreen.Interface;
using CheapSkies.Controller.Controller.Interface.ReservationScreen.Interface;
using CheapSkies.Controller.Controller.Reservation_Screen;
using CheapSkies.View.View.Interface;

namespace CheapSkies.Controller.Controller.Home_Screen
{
    public class HomeScreenController : IHomeScreenController
    {
        private readonly IFlightMaintenanceController _flightMaintenanceController;
        private readonly IReservationController _reservationController;
        private readonly IUI _ui;

        private readonly string[] menu = 
        {
            "Welcome to CheapSkies! What do you want to do?",
            "Press 1 and Enter => Go to Flight Maintenance Screen",
            "Press 2 and Enter => Go to Reservation Screen",
            "Press 3 and Enter => Exit CheapSkies\n"
        };
        
        public HomeScreenController(IFlightMaintenanceController flightMaintenanceController, IReservationController reservationController, IUI ui)
        {
            _flightMaintenanceController = flightMaintenanceController;
            _reservationController = reservationController;
            _ui = ui;
        }

        /// <summary>
        /// Opens the Home Screen. This will prompt the user to choose between opening Flight Maintenance Screen,
        /// Reservation Screen, or Exiting CheapSkies. This will run until the user inputted a valid option
        /// </summary>
        public void DisplayHomeScreen()
        {
            string userInput = "";

            while (userInput != "3") 
            {
                _ui.Clear();
                _ui.Display(menu);
                userInput = _ui.GetInput();

                switch (userInput)
                {
                    case "1":
                        _flightMaintenanceController.DisplayFlightMaintenanceScreen();
                        break;
                    case "2":
                        _reservationController.DisplayReservationScreen();
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
