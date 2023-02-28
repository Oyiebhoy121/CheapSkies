using CheapSkies.Controller.Controller.Reservation_Screen;
using CheapSkies.View;
namespace CheapSkies.Controller.Controller.Home_Screen
{
    public class HomeScreenController : IHomeScreenController
    {
        private UI _ui = new UI();

        private readonly string[] menu = 
        {
            "Welcome to CheapSkies! What do you want to do?",
            "Press 1 and Enter => Go to Flight Maintenance Screen",
            "Press 2 and Enter => Go to Reservation Screen",
            "Press 3 and Enter => Exit CheapSkies\n"
        };

        private readonly IFlightMaintenanceController _flightMaintenanceController;
        private readonly IReservationController _reservationController;

        public HomeScreenController(IFlightMaintenanceController flightMaintenanceController, IReservationController reservationController)
        {
            _flightMaintenanceController = flightMaintenanceController;
            _reservationController = reservationController;
        }

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
