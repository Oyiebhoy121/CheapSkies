using CheapSkies.Infrastructure;
using CheapSkies.Model.DataModel;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class SearchReservationController
    {
        private UI _ui = new UI();
        private ReservationRepository _reservationRepository = new ReservationRepository();
        private PassengerRepository _passengerRepository = new PassengerRepository();

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
        public void DisplayAllReservations()   //Refactor this method to work for View all reservations and View by PNR
        {
            List<ReservationBase> listOfReservations = new List<ReservationBase>();
            List<PassengerBase> listOfPassengers = new List<PassengerBase>();
            listOfReservations = _reservationRepository.GetReservationData();

            _ui.Clear();
            _ui.Display(menu[0]);
            _ui.Display(menu[1]);
            if (listOfReservations.Count == 0)
            {
                _ui.Display(menu[5]);
                _ui.ExitScreen();
                return;
            }

            int passengerCount = 0;
            foreach (ReservationBase reservation in listOfReservations)
            {
                _ui.Display(menu[2]);
                _ui.Display($"{reservation.PNR} \t {reservation.AirlineCode} \t\t {reservation.FlightNumber} \t\t {reservation.ArrivalStation} \t\t\t " +
                            $"{reservation.DepartureStation} \t\t\t {reservation.FlightDate} \t {reservation.NumberOfPassenger}");
                listOfPassengers = _passengerRepository.GetPassengerData(reservation.PNR);
                _ui.Display(menu[3]);
                foreach (PassengerBase passenger in listOfPassengers)
                {
                    _ui.Display($"\t\t{passengerCount + 1} \t\t\t {passenger.FirstName} \t {passenger.LastName} \t {passenger.BirthDate} \t {passenger.Age}\n");
                    passengerCount++;
                }
                passengerCount = 0;
            }
            _ui.Display(menu[4]);
            _ui.ExitScreen();
        }
        public void DisplaReservationsByPNR()
        {
            List<ReservationBase> listOfReservations = new List<ReservationBase>();
            List<PassengerBase> listOfPassengers = new List<PassengerBase>();
           
            _ui.Clear();
            _ui.Display(menu[0]);
            _ui.Display(menu[8]);
            string pnr = _ui.GetInput();

            listOfReservations = _reservationRepository.GetReservationData(pnr);
            if (listOfReservations.Count == 0)
            {
                _ui.Display(menu[6], pnr);
                _ui.ExitScreen();
                return;
            }

            
            int passengerCount = 0;
            foreach (ReservationBase reservation in listOfReservations)
            {
                _ui.Display(menu[2]);
                _ui.Display($"{reservation.PNR} \t {reservation.AirlineCode} \t\t {reservation.FlightNumber} \t\t {reservation.ArrivalStation} \t\t\t " +
                            $"{reservation.DepartureStation} \t\t\t {reservation.FlightDate} \t {reservation.NumberOfPassenger}");
                listOfPassengers = _passengerRepository.GetPassengerData(reservation.PNR);
                foreach (PassengerBase passenger in listOfPassengers)
                {
                    _ui.Display(menu[3]);
                    _ui.Display($"\t\t{passengerCount + 1} \t\t\t {passenger.FirstName} \t {passenger.LastName} \t {passenger.BirthDate} \t {passenger.Age}\n");
                    passengerCount++;
                }
                passengerCount = 0;
            }
            _ui.Display(menu[6], pnr);
            _ui.ExitScreen();
        }
    }
}