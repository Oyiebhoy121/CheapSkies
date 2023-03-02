using CheapSkies.Controller.Controller.Interface.ReservationScreen.Interface;
using CheapSkies.Controller.Validators.Interface;
using CheapSkies.Infrastructure.RepositoryInterface.PassengerRepository.Interface;
using CheapSkies.Model.ViewModel;
using CheapSkies.View.View.Interface;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class AddPassengerController : IAddPassengerController
    {
        private IPassengerValidator _passengerValidator;
        private IPassengerRepository _passengerRepository;
        private IUserInterface _userInterface;

        private readonly string[] menu =
        {
            "\nAdding Passengers",
            "\nInput the First Name of the Passenger (e.g. John, Felipe):",
            "\nInvalid Input. The input must be composed of 1-20 Characters only. Letters and spaces only",
            "\nInput the Last Name of the Passenger (e.g. White, Goleta):",
            "\nInvalid Input. The input must be composed of 1-20 Characters only. Letters and spaces only",
            "\nInput Passenger's BirthDate (Format: mm/dd/yyyy):",
            "\nInvalid Input. Follow the given format. Make sure that the date is not a future date",
            "\nAdding Passenger No. ",
            "\nHere is the Reservation Summary:",
            "\nAirline Code \t Flight Number \t Departure Station \t Arrival Station \t Flight Date \t Number Of Passengers",
            "\n\t\tPassenger Count \t First Name \t Last Name \t Birth Date \t Age",
            "\nPlease Confirm the reservation. Enter Y for Yes and N for No.",
            "\nReservation is Cancelled. Exiting Reservation Controller.",
            "\nReservation is Confirmed. Saving reservation.",
            "\nFlight added Successfully!"
        };
        
        public AddPassengerController(IPassengerValidator passengerValidator, IPassengerRepository passengerRepository, IUserInterface userInterface) 
        {
            _passengerValidator = passengerValidator;
            _passengerRepository = passengerRepository;
            _userInterface = userInterface;
        }

        /// <summary>
        /// This method prompts the user to add Passengers to the inputted Reservation. This will prompt the user to 
        /// input validat First Name, Last Name, and Birth Date of the passengers based on the number of passengers listed
        /// in the Reservation. Afterwards, it will show the reservation and passenger summary. If the user choose to proceed, 
        /// the input will be saved on PassengerRepository.txt and ReservationRepository.txt. If not, then the screen will go
        /// back to the Home Screen
        /// </summary>
        /// <returns>Integer of 1 if the Reservation is confirmed; otherwise, 0</returns>
        public int AddPassengers(Reservation reservation)
        {
            _userInterface.Display(menu[0]);
            List<Passenger> listOfPassengers = new List<Passenger>();
            string firstName;
            string lastName;
            string name;
            string rawBirthDate;
            DateOnly birthDate = new DateOnly();

            for (int i = 0; i < reservation.NumberOfPassenger; i++)
            {
                _userInterface.Display(menu[7], i + 1);

                firstName = GetPassengerInput(menu[1], menu[2], _passengerValidator.IsNameValid);
                lastName = GetPassengerInput(menu[3], menu[4], _passengerValidator.IsNameValid);
                rawBirthDate = GetPassengerInput(menu[5], menu[6], _passengerValidator.IsBirthDateValid);

                birthDate = DateOnly.Parse(rawBirthDate);

                Passenger passenger = new Passenger(reservation.PNR, firstName, lastName, birthDate);
                listOfPassengers.Add(passenger);
            }

            _userInterface.Display(menu[8]);
            _userInterface.Display(menu[9]);
            _userInterface.Display(reservation);
            _userInterface.Display(menu[10]);

            int passengerCount = 0;

            foreach (Passenger passenger in listOfPassengers)
            {
                _userInterface.Display(passenger, passengerCount);
                passengerCount++;   
            }

            _userInterface.Display(menu[11]);
            string userInput = "";

            while (userInput != "Y" || userInput != "N")
            {
                userInput = _userInterface.GetInput();

                if (userInput == "N")
                {
                    _userInterface.Display(menu[12]);

                    return 0;
                }   
                else if (userInput == "Y") 
                {
                    break;
                }
            }
            _userInterface.Display(menu[13]);

            _passengerRepository.SavePassenger(listOfPassengers);
            _userInterface.Display(menu[14]);
            _userInterface.ExitScreen();

            return 1;
        }

        /// <summary>
        /// This will prompt the user to input valid data. The validator will check the input. If the user inputted invalid data then, the the program 
        /// will loop again until the user inputted valid parameters
        /// </summary>
        /// <param name="message1">String of Message that requests the user to input a certain value</param>
        /// <param name="message2">String of Message that warns the user that the inputted string is not valid</param>
        /// <param name="validator">A Validator method that validates if the user inputted strings is valid or not</param>
        /// <returns>String of Valid Input</returns>
        private string GetPassengerInput(string message1, string message2, Func<string, bool> validator) //Candidate for Interface 
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
