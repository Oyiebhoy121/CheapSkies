using CheapSkies.Infrastructure;
using CheapSkies.Model.ViewModel;
using CheapSkies.Validator;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class CreateReservationController 
    {
        private UI _ui = new UI();
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
        public void CreateReservation()
        {
            _ui.Display(menu[0]);

            //Obtaining Validated Reservation Model Properties
            ReservationValidator reservationValidator = new ReservationValidator();
            string airlineCode = GetReservationInput(menu[1], menu[2], reservationValidator.ValidateAirlineCode);
            string rawFlightNumber = GetReservationInput(menu[3], menu[4], reservationValidator.ValidateFlightNumber);
            string arrivalStation = GetReservationInput(menu[5], menu[6], reservationValidator.ValidateStation);
            string departureStation = GetReservationInput(menu[7], menu[8], reservationValidator.ValidateStation);
            string rawFlightDate = GetReservationInput(menu[9], menu[10], reservationValidator.ValidateDate);
            string rawNumberOfPassengers = GetReservationInput(menu[11], menu[12], reservationValidator.ValidateNumberOfPassengers);

            //Obtaining Proper Data Type of Flight Model Properties
            int flightNumber = Int32.Parse(rawFlightNumber);
            DateOnly flightDate = DateOnly.Parse(rawFlightDate);
            int numberOfPassengers = Int32.Parse(rawNumberOfPassengers);

            //Getting existing lists of PNR 
            ReservationRepository reservationRepository = new ReservationRepository();
            List<string> listOfPNR = reservationRepository.GetPNRData();

            //Populating the Flight Model Properties
            Reservation reservation = new Reservation(airlineCode, flightNumber, arrivalStation, departureStation, flightDate, numberOfPassengers, listOfPNR);
            
            //Checking if the reservation created has a Flight available 
            if(!reservationValidator.ValidateIfReservationHasFlight(reservation))
            {
                _ui.Display(menu[15]);
                _ui.ExitScreen();
                return;
            }

            //Obtaining Passenger Data
            AddPassengerController addPassengerController = new AddPassengerController();
            int decision = addPassengerController.AddPassengers(reservation);
            if(decision == 0)
            {
                return;
            }
            //Saving the Reservation to Reservation Repository
            reservationRepository.SaveReservation(reservation);
            _ui.Display(menu[13]);
            _ui.Display(menu[14]);
            _ui.ExitScreen();
        }
        private string GetReservationInput(string message1, string message2, Func<string, bool> validator) //Candidate for Interface 
        {
            bool parse = false;
            string userInput = "";

            while (!parse)
            {
                _ui.Display(message1);
                userInput = _ui.GetInput();
                parse = validator(userInput);
                if (!parse)
                {
                    _ui.Display(message2);
                }
            }
            return userInput;
        }


    }
}
