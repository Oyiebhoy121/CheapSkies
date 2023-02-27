using CheapSkies.Controller.Controller.Flight_Maintenance_Screen;
using CheapSkies.Controller.Validators;
using CheapSkies.Validator;
using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class ReservationController : RecordController
    {
        private CreateReservationScreen _createReservationScreen;
        private ReservationValidator _reservationValidator;
        private UI _uiScreen;
        
        private CreateReservationController _createReservationController;
        private SearchReservationController _searchReservationController;
        private SearchScreen _searchScreen;
        private ScreenInputValidator _screenInputValidator;
        public ReservationController(CreateReservationScreen createReservationScreen, ReservationValidator reservationValidator,        
                                        UI uiScreen, CreateReservationController createReservationController,
                                        SearchReservationController searchReservationController, SearchScreen searchScreen,
                                        ScreenInputValidator screenInputValidator)
        {
            _createReservationScreen = createReservationScreen;
            _reservationValidator = reservationValidator;
            _uiScreen = uiScreen;
            _createReservationController = createReservationController;
            _searchReservationController = searchReservationController;
            _searchScreen = searchScreen;
            _screenInputValidator = screenInputValidator;
        }

        public void ShowReservationScreen()
        {
            string userInput;
            bool result; 

            do
            {
                userInput = _uiScreen.DisplayReservationScreenAndGetInput();
                result = _screenInputValidator.ValidateInput(userInput, maxOption: 4);
                if (!result)
                {
                    _uiScreen.DisplayInvalidScreenInpuMessage(max: "4");
                }
            } while (!result);

            switch (userInput)
            {
                case "1":
                    _createReservationController.CreateReservation();
                    break;
                case "2":
                    _searchReservationController.ShowReservations();
                    break;
                case "3":
                    string pnr= _searchScreen.AskForPNRAndGetInput();
                    _searchReservationController.ShowReservations(pnr);
                    break;
                case "4":
                    break;
            }
        }
       

    }
}
