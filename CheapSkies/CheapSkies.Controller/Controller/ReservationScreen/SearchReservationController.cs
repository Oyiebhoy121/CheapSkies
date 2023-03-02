using CheapSkies.Controller.Controller.Interface.ReservationScreen.Interface;
using CheapSkies.Infrastructure.Repository.Interface.PassengerRepository.Interface;
using CheapSkies.Infrastructure.Repository.Interface.ReservationRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.View.View.Interface;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class SearchReservationController : ISearchReservationController
    {
        private IUserInterface _userInterface;
        private IReservationRepository _reservationRepository;
        private IPassengerRepository _passengerRepository;

        private readonly string[] menu =
        {
            "Displaying Reservations",
            "\nShowing Reservation Results:",
            "\nPNR \t Airline Code \t Flight Number \t Arrival Station \t Departure Station \t Flight Date \t Number Of Passenger",
            "\n\t\tPassenger Count \t First Name \t Last Name \t Birth Date \t Age",
            "\nSuccessfully Displayed All Reservations",
            "\nNo Reservations",
            "\n\nSuccessfully Displayed All Reservations based on PNR ",
            "\nNo Reservations found based on Input PNR",
            "\nInput the 6 Character PNR:"
        };

        public SearchReservationController(IUserInterface userInterface, IReservationRepository reservationRepository, IPassengerRepository passengerRepository)
        {
            _userInterface = userInterface;
            _reservationRepository = reservationRepository;
            _passengerRepository = passengerRepository;
        }

        /// <summary>
        /// This will prompt display all the properties of all Reservations 
        /// in the ReservationRepository with the accompanying Passengers of the same PNR 
        /// from the PassengerRepository
        /// </summary>
        public void DisplayAllReservations()   //Refactor this method to work for View all reservations and View by PNR
        {
            List<ReservationBase> listOfReservations = new List<ReservationBase>();
            List<PassengerBase> listOfPassengers = new List<PassengerBase>();
            listOfReservations = _reservationRepository.GetReservationData();

            _userInterface.Clear();
            _userInterface.Display(menu[0]);
            _userInterface.Display(menu[1]);
            if (listOfReservations.Count == 0)
            {
                _userInterface.Display(menu[5]);
                _userInterface.ExitScreen();
                return;
            }

            int passengerCount = 0;
            foreach (ReservationBase reservation in listOfReservations)
            {
                _userInterface.Display(menu[2]);
                _userInterface.Display(reservation);
                listOfPassengers = _passengerRepository.GetPassengerData(reservation.PNR);
                _userInterface.Display(menu[3]);
                foreach (PassengerBase passenger in listOfPassengers)
                {
                    _userInterface.Display(passenger, passengerCount);
                    passengerCount++;
                }
                passengerCount = 0;
            }
            _userInterface.Display(menu[4]);
            _userInterface.ExitScreen();
        }

        /// <summary>
        /// This will prompt the user to input the PNR of the desired reservation. Then this
        /// will display all the properties of the Reservation with the corresponding PNR 
        /// in the ReservationRepository with the accompanying Passengers of the same PNR 
        /// from the PassengerRepository.
        /// </summary>
        public void DisplaReservationsByPNR()
        {
            List<ReservationBase> listOfReservations = new List<ReservationBase>();
            List<PassengerBase> listOfPassengers = new List<PassengerBase>();
           
            _userInterface.Clear();
            _userInterface.Display(menu[0]);
            _userInterface.Display(menu[8]);
            string pnr = _userInterface.GetInput();

            listOfReservations = _reservationRepository.GetReservationData(pnr);

            if (listOfReservations.Count == 0)
            {
                _userInterface.Display(menu[6], pnr);
                _userInterface.ExitScreen();
                return;
            }

            int passengerCount = 0;
            foreach (ReservationBase reservation in listOfReservations)
            {
                _userInterface.Display(menu[2]);
                _userInterface.Display(reservation);
                listOfPassengers = _passengerRepository.GetPassengerData(reservation.PNR);
                foreach (PassengerBase passenger in listOfPassengers)
                {
                    _userInterface.Display(menu[3]);
                    _userInterface.Display(passenger, passengerCount);
                    passengerCount++;
                }
                passengerCount = 0;
            }
            _userInterface.Display(menu[6], pnr);
            _userInterface.ExitScreen();
        }

    }
}