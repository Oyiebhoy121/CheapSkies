using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Model.ViewModel;
using CheapSkies.Validator;
using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class CreateReservationController : RecordController
    {
        private CreateReservationScreen _createReservationScreen;
        private ReservationValidator _reservationValidator;
        private ReservationRepository _reservaitonRepository;
        private AddPassengerController _addPassengerController;
        public CreateReservationController(CreateReservationScreen createReservationScreen, ReservationValidator reservationValidator,
                                            ReservationRepository reservationRepository, AddPassengerController addPassengerController)
        {
            _createReservationScreen = createReservationScreen;
            _reservationValidator = reservationValidator;
            _reservaitonRepository = reservationRepository;
            _addPassengerController = addPassengerController;
        }

        public void CreateReservation()
        {
            bool parse = false;
            
            _createReservationScreen.DisplayCreateReservationMessage();

            string airlineCode = GetAirlineCode();
            int flightNumber = GetFlightNumber();
            string arrivalStation = GetStation("Arrival");
            string departureStation = GetStation("Departure");
            DateTime flightDate = GetFlightDate();
            int numberOfPassengers = GetNumberOfPassengers();

            List<string> listOfPNR = _reservaitonRepository.GetPNR();
            Reservation reservation = new Reservation(airlineCode, flightNumber, arrivalStation, departureStation,
                                                        flightDate, numberOfPassengers, listOfPNR);

            _addPassengerController.AddPassengers(reservation.NumberOfPassenger, reservation.PNR);
            _reservaitonRepository.SaveReservation(reservation);
            _createReservationScreen.DisplaySuccessfullyCreatedReservation();
        }

        private DateTime GetFlightDate()
        {
            string flightDate;
            bool parse;

            do
            {
                flightDate = _createReservationScreen.AskForFlightDateAndGetInput();
                parse = _reservationValidator.ValidateDate(flightDate);
            } while (!parse);
            return DateTime.Parse(flightDate);
        }

        private int GetNumberOfPassengers()
        {
            string numberOfPassengers;
            bool parse;

            do
            {
                numberOfPassengers = _createReservationScreen.AskForNumberOfPassengersAndGetInput();
                parse = _reservationValidator.ValidatePassengerNumber(numberOfPassengers);
            } while (!parse);
            return Int32.Parse(numberOfPassengers);
        }



        
    }
}
