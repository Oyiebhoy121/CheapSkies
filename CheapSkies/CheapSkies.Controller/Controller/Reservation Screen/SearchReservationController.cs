using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Model.DataModel;
using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class SearchReservationController
    {
        private UIScreen _uiScreen;
        private ReservationRepository _reservationRepository;
        private SearchScreen _searchScreen;
        private PassengerRepository _passengerRepository;

        public SearchReservationController(UIScreen uiScreen, ReservationRepository reservationRepository,
                                            SearchScreen searchScreen, PassengerRepository passengerRepository)
        {
            _uiScreen = uiScreen;
            _reservationRepository = reservationRepository;
            _searchScreen = searchScreen;
            _passengerRepository = passengerRepository;
        }



        public void ShowReservations()
        {
            List<ReservationBase> listOfReservations = new List<ReservationBase>();
            listOfReservations = _reservationRepository.GetReservationData();

            _searchScreen.DisplayAllReservations();
            _searchScreen.ShowReservations(listOfReservations);
        }

        public void ShowReservations(string pnr)
        {
            List<ReservationBase> listOfReservations = new List<ReservationBase>();
            listOfReservations = _reservationRepository.GetReservationData(pnr);

            List<PassengerBase> listOfPassengers = new List<PassengerBase>();
            listOfPassengers = _passengerRepository.GetPassengerData(pnr);

            _searchScreen.DisplayReservationsByPNR(pnr);
            _searchScreen.ShowReservations(listOfReservations);
            _searchScreen.DisplayPassengersByPNR(pnr);
            _searchScreen.ShowPassengers(listOfPassengers);
        }
    }
}