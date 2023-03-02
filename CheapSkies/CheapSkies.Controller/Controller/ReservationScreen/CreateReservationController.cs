using CheapSkies.Controller.Controller.Interface.ReservationScreen.Interface;
using CheapSkies.Controller.Validators;
using CheapSkies.Controller.Validators.Interface;
using CheapSkies.Infrastructure.Repositories.ReservationRepository;
using CheapSkies.Infrastructure.RepositoryInterface.ReservationRepository.Interface;
using CheapSkies.Model.ViewModel;
using CheapSkies.View.View;
using CheapSkies.View.View.Interface;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class CreateReservationController : ICreateReservationController
    {
        private IUserInterface _userInterface;
        private IReservationValidator _reservationValidator;
        private IReservationRepository _reservationRepository;
        private IAddPassengerController _addPassengerController;

        private readonly string[] menu =
        {
            "Creating Reservation",
            "\nInput the Airline Code (e.g. 5J, TAM, A4C):",
            "\nInvalid Input. The input must be 2-3 Uppercased Alphanumberic Code. Numeric Character may only appear once.",
            "\nInput Flight Number (e.g. 1, 124, 9999):",
            "\nInvalid Input. The input must be an an integer between 1-9999",
            "\nInput Arrival Station (e.g. MNL, AB3, NRT):",
            "\nInvalid Input. The input must be exaclty 3 Uppercased Alphanumberic Code. Numeric Characters are optional. First character must be a letter",
            "\nInput Departure Station (e.g. MNL, AB3, NRT):",
            "\nInvalid Input. The input must be exaclty 3 Uppercased Alphanumberic Code. Numeric Characters are optional. First character must be a letter",
            "\nInput the Flight Date (Format: mm/dd/yyy)",
            "\nInvalid Input. Follow the given format. Make sure that the date is not a past date",
            "\nInput the number of passengers you are booking (1-5 passengers only):  ",
            "\nInvalid Input. Please select a number from 1 to 5 only",
            "\nCreating a Reservation",
            "\nSuccessfully Created a Reservation!",
            "\n***The Reservation you are creating is Invalid. Please reserve only for existing flights.***"
        };

        public CreateReservationController(IReservationValidator reservationValidator, IReservationRepository reservationRepository, IUserInterface userInterface,
                                            IAddPassengerController addPassengerController)
        {
            _reservationValidator = reservationValidator;
            _reservationRepository = reservationRepository;
            _userInterface = userInterface;
            _addPassengerController = addPassengerController;
        }

        /// <summary>
        /// Opens the Create Reservation Screen. This will prompt the user to input valid Airline Code, Flight Number, Arrival Station,
        /// Departure Station, Flight Date, and Number of Passengers. Afterward, the valid inputs will be stored to the ReservationRepository.txt
        /// as a string that are separated by strings
        /// </summary>
        public void CreateReservation()
        {
            _userInterface.Display(menu[0]);

            string airlineCode = GetReservationInput(menu[1], menu[2], ((IRecordValidator)_reservationValidator).IsAirlineCodeValid);
            string rawFlightNumber = GetReservationInput(menu[3], menu[4], ((IRecordValidator)_reservationValidator).IsFlightNumberValid);
            string arrivalStation = GetReservationInput(menu[5], menu[6], ((IRecordValidator)_reservationValidator).IsStationValid);
            string departureStation = GetReservationInput(menu[7], menu[8], ((IRecordValidator)_reservationValidator).IsStationValid);
            string rawFlightDate = GetReservationInput(menu[9], menu[10], _reservationValidator.IsFlightDateValid);
            string rawNumberOfPassengers = GetReservationInput(menu[11], menu[12], _reservationValidator.IsNumberOfPassengersValid);

            int flightNumber = Int32.Parse(rawFlightNumber);
            DateOnly flightDate = DateOnly.Parse(rawFlightDate);
            int numberOfPassengers = Int32.Parse(rawNumberOfPassengers);

            List<string> listOfPNR = _reservationRepository.GetPNRData();

            Reservation reservation = new Reservation(airlineCode, flightNumber, arrivalStation, departureStation, flightDate, numberOfPassengers, listOfPNR);
            
            if(!_reservationValidator.IsFlightValidForReservation(reservation))
            {
                _userInterface.Display(menu[15]);
                _userInterface.ExitScreen();
                return;
            }

            int decision = _addPassengerController.AddPassengers(reservation);

            if(decision == 0)
            {
                return;
            }

            _reservationRepository.SaveReservation(reservation); 
            _userInterface.Display(menu[13]);
            _userInterface.Display(menu[14]);
            _userInterface.ExitScreen();
        }

        /// <summary>
        /// This will prompt the user to input valid Reservation data. The validator will check the input. If the user inputted invalid data then, the the program 
        /// will loop again until the user inputted valid parameters
        /// </summary>
        /// <param name="message1">String of Message that requests the user to input a certain value</param>
        /// <param name="message2">String of Message that warns the user that the inputted string is not valid</param>
        /// <param name="validator">A Validator method that validates if the user inputted strings is valid or not</param>
        /// <returns>String of Valid Input</returns>
        private string GetReservationInput(string message1, string message2, Func<string, bool> validator) //Candidate for Interface 
        {
            bool parse = false;
            string userInput = "";

            while (!parse)
            {
                _userInterface.Display(message1);
                userInput = _userInterface.GetInput();
                parse = validator(userInput);
                if (!parse)
                {
                    _userInterface.Display(message2);
                }
            }

            return userInput;
        }

    }
}
