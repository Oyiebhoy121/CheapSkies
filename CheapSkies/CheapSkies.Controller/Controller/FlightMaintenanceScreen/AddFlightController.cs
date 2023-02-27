using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Model.ViewModel;
using CheapSkies.View;
using System.ComponentModel.Design;
using System.Dynamic;

namespace CheapSkies.Controller.Controller
{
    public class AddFlightController 
    {
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
            "\nPress any key to go back Home"
        };

        public void AddFlight()
        {
            UI ui = new UI();
            ui.Clear();
            ui.Display(menu[0]);

            //Obtain and Validate Flight Model Properties
            FlightValidator flightValidator = new FlightValidator();
            string airlineCode = GetFlightInput(menu[1], menu[2], flightValidator.ValidateAirlineCode);
            string rawFlightNumber = GetFlightInput(menu[3], menu[4], flightValidator.ValidateFlightNumber);
            string arrivalStation = GetFlightInput(menu[5], menu[6], flightValidator.ValidateStation);
            string departureStation = GetFlightInput(menu[7], menu[8], flightValidator.ValidateStation);
            string rawScheduleTimeOfArrival = GetFlightInput(menu[9], menu[10], flightValidator.ValidateTimeFormat);
            string rawScheduleTimeOfDeparture = GetFlightInput(menu[11], menu[12], flightValidator.ValidateTimeFormat);

            //Obtain Proper Data Type of Flight Model Properties
            int flightNumber = Int32.Parse(rawFlightNumber);
            TimeSpan scheduleTimeOfArrival = TimeSpan.Parse(rawScheduleTimeOfArrival);
            TimeSpan scheduleTimeOfDeparture = TimeSpan.Parse(rawScheduleTimeOfArrival);

            //Populating the Flight Model Properties
            Flight flight = new Flight(airlineCode, flightNumber, arrivalStation, departureStation,
                                        scheduleTimeOfArrival, scheduleTimeOfDeparture);

            //Saving the Flight to Flight Repository
            FlightRepository flightRepository = new FlightRepository();
            flightRepository.SaveFlight(flight);
            ui.Display(menu[13]);
            ui.Display(menu[14]);
        }

        private string GetFlightInput(string message1, string message2, Func<string, bool> validator)
        {
            bool parse = false;
            string userInput = "";

            UI ui = new UI();

            while(!parse)
            {
                ui.Display(message1);
                userInput = ui.GetInput();
                parse = validator(userInput);
                if(!parse)
                {
                    ui.Display(message2);
                }
            }
            return userInput;
        }
    }
}
