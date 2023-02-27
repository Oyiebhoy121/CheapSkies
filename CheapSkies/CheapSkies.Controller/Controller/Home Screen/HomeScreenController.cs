using CheapSkies.Controller.Controller.Flight_Maintenance_Screen;
using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller.Home_Screen
{
    public class HomeScreenController
    {
        private AddFlightController _addFlightController;
        private SearchFlightController _searchFlightController;
        private UIScreen _uiScreen;
        private ScreenInputValidator _screenInputValidator;
        private FlightMaintenanceController _flightMaintenanceController;
        public HomeScreenController(AddFlightController addFlightController, SearchFlightController searchFlightController,
                                        UIScreen uiScreen, ScreenInputValidator screenInputValidator,
                                        FlightMaintenanceController flightMaintenanceController)
        {
            _addFlightController = addFlightController;
            _searchFlightController = searchFlightController;
            _uiScreen = uiScreen;
            _screenInputValidator = screenInputValidator;
            _flightMaintenanceController = flightMaintenanceController;
        }

        public int DisplayHomeScreen()
        {
            string userInput;
            bool validationResult;
            do
            {
                userInput = _uiScreen.DisplayHomeScreenAndGetInput();
                validationResult = _screenInputValidator.ValidateInput(userInput, maxOption: 3);
                if (!validationResult)
                {
                    _uiScreen.DisplayInvalidScreenInpuMessage(max: "3");
                }
            }   while(!validationResult);

            switch (userInput)
            {
                case "1":
                    _flightMaintenanceController.ShowFlightMaintenanceScreen();
                    break;
                case "2":
                    //Show Reservation Screen
                    break;
                case "3":
                    return 1;
            }
            return 0;
        }





    }
}
