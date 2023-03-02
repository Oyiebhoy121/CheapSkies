using CheapSkies.Controller.Controller.Interface.FlightMaintenancScreen.Interface;
using CheapSkies.Controller.Validators;
using CheapSkies.Controller.Validators.Interface;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.ViewModel;
using CheapSkies.View.View;
using CheapSkies.View.View.Interface;
using Interfaces;

namespace CheapSkies.Controller.Controller
{
    public class AddFlightController : IAddFlightController //IGetValidInput
    {
        private IFlightValidator _flightValidator;
        private IFlightRepository _flightRepository;
        private IUserInterface _userInterface;

        private readonly string[] menu =
        {
            "Adding Flight",
            "\nInput the Airline Code (e.g. 5J, TAM, A4C):",
            "\nInvalid Input. The input must be 2-3 Uppercased Alphanumberic Code. Numeric Character may only appear once.",
            "\nInput Flight Number (e.g. 1, 124, 9999):",
            "\nInvalid Input. The input must be an an integer between 1-9999",
            "\nInput Arrival Station (e.g. MNL, AB3, NRT):",
            "\nInvalid Input. The input must be exaclty 3 Uppercased Alphanumberic Code. Numeric Characters are optional. First character must be a letter",
            "\nInput Departure Station (e.g. MNL, AB3, NRT):",
            "\nInvalid Input. The input must be exaclty 3 Uppercased Alphanumberic Code. Numeric Characters are optional. First character must be a letter",
            "\nInput Schedule Time of Arrival (Format hh:mm)",
            "\nInvalid Input. The input must only be of the given format",
            "\nInput Schedule Time of Departure (Format hh:mm)",
            "\nInvalid Input. The input must only be of the given format",
            "\nFlight added Successfully!",
            "\nFlight added Successfully!"
        };

        public AddFlightController(IFlightValidator flightValidator, IFlightRepository flightRepository, IUserInterface userInterface)
        {
            _flightValidator = flightValidator;
            _flightRepository = flightRepository;
            _userInterface = userInterface;
        }

        /// <summary>
        /// Opens the Add Flight Screen. This will prompt the user to input valid Airline Code, Flight Number, Arrival Station,
        /// Departure Station, Schedule of Time of Arrival and Departure. Afterward, the valid inputs will be stored to the FlightRepository.txt
        /// as a string that are separated by strins
        /// </summary>
        public void AddFlight()
        {
            _userInterface.Clear();
            _userInterface.Display(menu[0]);

            string airlineCode = GetValidInput(menu[1], menu[2], ((IRecordValidator)_flightValidator).IsAirlineCodeValid);
            string rawFlightNumber = GetValidInput(menu[3], menu[4], ((IRecordValidator)_flightValidator).IsFlightNumberValid);
            string arrivalStation = GetValidInput(menu[5], menu[6], ((IRecordValidator)_flightValidator).IsStationValid);
            string departureStation = GetValidInput(menu[7], menu[8], ((IRecordValidator)_flightValidator).IsStationValid);
            string scheduleTimeOfArrival = GetValidInput(menu[9], menu[10], _flightValidator.IsTimeFormatValid);
            string scheduleTimeOfDeparture = GetValidInput(menu[11], menu[12], _flightValidator.IsTimeFormatValid);

            int flightNumber = Int32.Parse(rawFlightNumber);

            Flight flight = new Flight(airlineCode, flightNumber, arrivalStation, departureStation, scheduleTimeOfArrival, scheduleTimeOfDeparture);

            if (_flightValidator.IsFlightDuplicate(flight))
            {
                _userInterface.Display(menu[13]);
                _userInterface.ExitScreen();

                return;
            }

            _flightRepository.SaveFlight(flight);
            _userInterface.Display(menu[13]);
            _userInterface.ExitScreen();
        }

        /// <summary>
        /// This will prompt the user to input valid data. The validator will check the input. If the user inputted invalid data then, the the program 
        /// will loop again until the user inputted valid parameters
        /// </summary>
        /// <param name="message1">String of Message that requests the user to input a certain value</param>
        /// <param name="message2">String of Message that warns the user that the inputted string is not valid</param>
        /// <param name="validator">A Validator method that validates if the user inputted strings is valid or not</param>
        /// <returns>String of Valid Input</returns>
        private string GetValidInput(string message1, string message2, Func<string, bool> validator)    //Candidate for IGetValidInput
        {
            bool parse = false;
            string userInput = "";

            while(!parse)
            {
                _userInterface.Display(message1);
                userInput = _userInterface.GetInput();
                parse = validator(userInput);

                if(!parse)
                {
                    _userInterface.Display(message2);
                }
            }

            return userInput;
        }

    }
}
