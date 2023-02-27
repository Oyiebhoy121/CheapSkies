using CheapSkies.Controller;
using CheapSkies.Controller.Controller;
using CheapSkies.Controller.Controller.Flight_Maintenance_Screen;
using CheapSkies.Controller.Controller.Home_Screen;
using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
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

            var homeScreenController = new HomeScreenController(addFlightController, searchFlightController, uiScreen, screenInputValidator, 
                                                                    flightMaintenanceController);

            //Putting Fields
            int result = 0;
            do
            {
                result = homeScreenController.DisplayHomeScreen();
            }   while(result != 1);
        }
    }
}