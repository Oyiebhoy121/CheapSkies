using CheapSkies.Controller;
using CheapSkies.Controller.Controller;
using CheapSkies.Controller.Controller.Flight_Maintenance_Screen;
using CheapSkies.Controller.Controller.Home_Screen;
using CheapSkies.Controller.Controller.Reservation_Screen;
using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Validator;
using CheapSkies.View;

namespace CheapSkiesFinal
{
    public class Program
    {
        public static void Main()
        {
            //Putting dependencies 
            var uiScreen = new UIScreen();
            var screenInputValidator = new ScreenInputValidator();
            var searchScreen = new SearchScreen();
            
            var addFlightScreen = new AddFlightScreen();
            var flightValidator = new FlightValidator();
            var flightRepository = new FlightRepository();
            

            var addFlightController = new AddFlightController(addFlightScreen, flightValidator, flightRepository);
            var searchFlightController = new SearchFlightController(addFlightScreen, flightValidator, flightRepository, 
                                                                        uiScreen, addFlightController, screenInputValidator,
                                                                        searchScreen);
            var flightMaintenanceController = new FlightMaintenanceController(addFlightController, searchFlightController, uiScreen,
                                                                                screenInputValidator);

            var createReservationScreen = new CreateReservationScreen();
            var reservationValidator = new ReservationValidator();
            var reservationRepository = new ReservationRepository();
            var addPassengerScreen = new AddPassengerScreen();
            var passengerValidator = new PassengerValidator();  
            var passengerRepository = new PassengerRepository();
            var addPassengerController = new AddPassengerController(addPassengerScreen, passengerValidator, passengerRepository);

            var createReservationController = new CreateReservationController(createReservationScreen, reservationValidator, 
                                                                                reservationRepository, addPassengerController);

            var searchReservationController = new SearchReservationController(uiScreen, reservationRepository,searchScreen,
                                                                                passengerRepository);

            var reservationController = new ReservationController(createReservationScreen, reservationValidator, uiScreen,
                                                                    createReservationController, searchReservationController,
                                                                    searchScreen, screenInputValidator);

            var homeScreenController = new HomeScreenController(addFlightController, searchFlightController, uiScreen, screenInputValidator, 
                                                                    flightMaintenanceController, reservationController);

            //Putting Fields
            int result = 0;
            do
            {
                result = homeScreenController.DisplayHomeScreen();
            }   while(result != 1);
        }
    }
}