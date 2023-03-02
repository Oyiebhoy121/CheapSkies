using CheapSkies.Controller.Controller.Interface.ReservationScreen.Interface;
using CheapSkies.View.View;
using CheapSkies.View.View.Interface;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class ReservationController : IReservationController
    {
        private ICreateReservationController _createReservationController;
        private ISearchReservationController _searchReservationController;
        private IUI _ui;

        private readonly string[] menu =
        {
            "Reservation Controller",
            "Press 1 and Enter => Create a Reservation",
            "Press 2 and Enter => List all Reservations",
            "Press 3 and Enter => List Reservations by PNR",
            "Press 4 and Enter => Go Back\n"
        };
        
        public ReservationController(ICreateReservationController createReservationController, ISearchReservationController searchReservationController, IUI ui)
        {
            
            _createReservationController = createReservationController;
            _searchReservationController = searchReservationController;
            _ui = ui;
        }

        /// <summary>
        /// Opens the Reservation  Screen. This will prompt the user to choose between Creating a Reservation, Displaying All Reservations, 
        /// Displaying Reservations based on PNR, or back to the Home Screen. This will run until the user inputted a valid option
        /// </summary>
        public void DisplayReservationScreen()
        {
            string userInput = "";

            while (userInput != "1" || userInput != "2" || userInput != "3" || userInput != "4")
            {
                _ui.Clear();
                _ui.Display(menu);
                userInput = _ui.GetInput();

                switch (userInput)
                {
                    case "1":
                        _createReservationController.CreateReservation();
                        return;
                    case "2":
                        _searchReservationController.DisplayAllReservations();
                        return;
                    case "3":
                        _searchReservationController.DisplaReservationsByPNR();
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
