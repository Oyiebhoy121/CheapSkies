using CheapSkies.View;
namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class ReservationController : IReservationController
    {
        private readonly string[] menu =
        {
            "Reservation Controller",
            "Press 1 and Enter => Create a Reservation",
            "Press 2 and Enter => List all Reservations",
            "Press 3 and Enter => List Reservations by PNR",
            "Press 4 and Enter => Go Back\n"
        };
        public void DisplayReservationScreen()
        {
            UI ui = new UI();
            CreateReservationController createReservationController = new CreateReservationController();
            SearchReservationController searchReservationController = new SearchReservationController();
            string userInput = "";

            while (userInput != "1" || userInput != "2" || userInput != "3" || userInput != "4")
            {
                ui.Clear();
                ui.Display(menu);
                userInput = ui.GetInput();

                switch (userInput)
                {
                    case "1":
                        createReservationController.CreateReservation();
                        return;
                    case "2":
                        searchReservationController.DisplayAllReservations();
                        return;
                    case "3":
                        searchReservationController.DisplaReservationsByPNR();
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
