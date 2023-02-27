using CheapSkies.Controller.Controller.Flight_Maintenance_Screen;
using CheapSkies.Controller.Validators;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller
{
    public class FlightMaintenanceController
    {
        private AddFlightController _addFlightController;
        private SearchFlightController _searchFlightController;
        private UIScreen _uiScreen;
        private ScreenInputValidator _screenInputValidator;

        public FlightMaintenanceController(AddFlightController addFlightController, SearchFlightController searchFlightController,
                                            UIScreen uIScreen, ScreenInputValidator screenInputValidator)
        {
            _addFlightController = addFlightController;
            _searchFlightController = searchFlightController;
            _uiScreen = uIScreen;
            _screenInputValidator = screenInputValidator;
        }

        public void ShowFlightMaintenanceScreen()
        {
            string userInput;
            bool result;

            do
            {
                userInput = _uiScreen.DisplayFlightMaintenanceScreenAndGetInput();
                result = _screenInputValidator.ValidateInput(userInput, 3);
                if (!result)
                {
                    _uiScreen.DisplayInvalidScreenInpuMessage(max:"3");
                }
            } while (!result);

            switch(userInput)
            {
                case "1":
                    _addFlightController.AddFlight();
                    break;
                case "2":
                    _searchFlightController.SearchFlight();
                    break;
                case "3":
                    //HomeScreen();
                    break;
            }
        }
    }
}
