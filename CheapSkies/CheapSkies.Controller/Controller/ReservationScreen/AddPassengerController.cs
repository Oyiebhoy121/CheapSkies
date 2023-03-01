using CheapSkies.Controller.ReservationScreen.Interface;
using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Model.ViewModel;
using CheapSkies.View;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class AddPassengerController : IAddPassengerController
    {
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
        private UI _ui = new UI();

        public int AddPassengers(Reservation reservation)
        {
            _ui.Display(menu[0]);
            List<Passenger> listOfPassengers = new List<Passenger>();
            string firstName;
            string lastName;
            string name;
            string rawBirthDate;
            DateOnly birthDate = new DateOnly();
            PassengerValidator passengerValidator = new PassengerValidator();
            

            for (int i = 0; i < reservation.NumberOfPassenger; i++)
            {
                _ui.Display(menu[7], i + 1);
                // Obtain and Validate Passenger Model Properties
                firstName = GetPassengerInput(menu[1], menu[2], passengerValidator.ValidateName);
                lastName = GetPassengerInput(menu[3], menu[4], passengerValidator.ValidateName);
                rawBirthDate = GetPassengerInput(menu[5], menu[6], passengerValidator.ValidateDate);

                //Obtain Proper Data Type of Passenger Model Properties
                birthDate = DateOnly.Parse(rawBirthDate);

                //Populating the Passenger Model Properties
                Passenger passenger = new Passenger(reservation.PNR, firstName, lastName, birthDate);
                listOfPassengers.Add(passenger);
            }

            //Reservation Summary
            _ui.Display(menu[8]);
            _ui.Display(menu[9]);
            _ui.Display($"{reservation.AirlineCode} \t\t {reservation.FlightNumber} \t\t {reservation.ArrivalStation} \t\t\t " +
                            $"{reservation.DepartureStation} \t\t\t {reservation.FlightDate} \t {reservation.NumberOfPassenger}");
            _ui.Display(menu[10]);
            int passengerCount = 0;
            foreach (Passenger passenger in listOfPassengers)
            {
                _ui.Display($"\t\t{ passengerCount + 1} \t\t\t { passenger.FirstName} \t { passenger.LastName} \t { passenger.BirthDate} \t { passenger.Age}\n");
                passengerCount++;   
            }

            //Confirming Booking 
            _ui.Display(menu[11]);
            string userInput = "";
            while (userInput != "Y" || userInput != "N")
            {
                userInput = _ui.GetInput();
                if (userInput == "N")
                {
                    _ui.Display(menu[12]);
                    return 0;
                }   
                else if (userInput == "Y") 
                {
                    break;
                }
            }
            _ui.Display(menu[13]);

            //Saving the Passenger to Flight Repository
            PassengerRepository passengerRepository = new PassengerRepository();
            passengerRepository.SavePassenger(listOfPassengers);
            _ui.Display(menu[14]);
            _ui.ExitScreen();
            return 1;
        }
        private string GetPassengerInput(string message1, string message2, Func<string, bool> validator) //Candidate for Interface 
        {
            bool parse = false;
            string userInput = "";

            UI ui = new UI();

            while (!parse)
            {
                ui.Display(message1);
                userInput = ui.GetInput();
                parse = validator(userInput);
                if (!parse)
                {
                    ui.Display(message2);
                }
            }
            return userInput;
        }


    }
}
