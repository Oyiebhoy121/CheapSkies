using CheapSkies.Controller.Controller.FlightMaintenancScreen.Interface;
using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Model.ViewModel;
using CheapSkies.View;
using Interfaces;

namespace CheapSkies.Controller.Controller
{
    public class AddFlightController : IAddFlightController //IGetValidatedInput
    {
        private UI _ui = new UI();
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

        public void AddFlight()
        {
            _ui.Clear();
            _ui.Display(menu[0]);

            //Obtain and Validate Flight Model Properties
            FlightValidator flightValidator = new FlightValidator();
            string airlineCode = GetValidatInput(menu[1], menu[2], flightValidator.ValidateAirlineCode);
            string rawFlightNumber = GetValidatInput(menu[3], menu[4], flightValidator.ValidateFlightNumber);
            string arrivalStation = GetValidatInput(menu[5], menu[6], flightValidator.ValidateStation);
            string departureStation = GetValidatInput(menu[7], menu[8], flightValidator.ValidateStation);
            string scheduleTimeOfArrival = GetValidatInput(menu[9], menu[10], flightValidator.ValidateTimeFormat);
            string scheduleTimeOfDeparture = GetValidatInput(menu[11], menu[12], flightValidator.ValidateTimeFormat);

            //Obtain Proper Data Type of Flight Model Properties
            int flightNumber = Int32.Parse(rawFlightNumber);
     

            //Populating the Flight Model Properties
            Flight flight = new Flight(airlineCode, flightNumber, arrivalStation, departureStation, scheduleTimeOfArrival, scheduleTimeOfDeparture);


            if (flightValidator.ValidateIfInputIsDuplicate(flight))
            {
                _ui.Display(menu[13]);
                _ui.ExitScreen();
                return;
            }

            //Saving the Flight to Flight Repository
            FlightRepository flightRepository = new FlightRepository();
            flightRepository.SaveFlight(flight);
            _ui.Display(menu[13]);
            _ui.ExitScreen();
        }
        private string GetValidatInput(string message1, string message2, Func<string, bool> validator)
        {
            bool parse = false;
            string userInput = "";

            while(!parse)
            {
                _ui.Display(message1);
                userInput = _ui.GetInput();
                parse = validator(userInput);
                if(!parse)
                {
                    _ui.Display(message2);
                }
            }
            return userInput;
        }
    }
}
