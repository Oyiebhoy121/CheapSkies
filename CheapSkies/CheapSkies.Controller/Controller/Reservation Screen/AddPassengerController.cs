using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Model.ViewModel;
using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller.Reservation_Screen
{
    public class AddPassengerController
    {
        private AddPassengerScreen _addPassengerScreen;
        private PassengerValidator _passengerValidator;
        private PassengerRepository _passengerRepository;
        public AddPassengerController(AddPassengerScreen addPassengerScreen, PassengerValidator passengerValidator,
                                        PassengerRepository passengerRepository)
        {
            _addPassengerScreen = addPassengerScreen;
            _passengerValidator = passengerValidator;
            _passengerRepository = passengerRepository;
        }

        public void AddPassengers(int numberOfPassengers, string pnr)
        {
            _addPassengerScreen.DisplayAddPassengerMessage();
            string firstName, lastName;
            DateTime birthDate;
            List<Passenger> listOfPassengers = new List<Passenger>();
            

            for(int i=0; i< numberOfPassengers; i++)
            {
                firstName = GetName("First");
                lastName = GetName("Last");
                birthDate = GetBirthDate();

                Passenger passenger = new Passenger(pnr, firstName, lastName, birthDate);
                listOfPassengers.Add(passenger);
            }
            
            foreach(Passenger passenger in listOfPassengers)
            {
                _passengerRepository.SavePassenger(passenger);
            }
            _addPassengerScreen.DisplaySuccessfullyAddedPassengers();
        }

        public string GetName(string firstOrLastName)
        {
            string name;
            bool parse;

            do
            { 
                name = _addPassengerScreen.AskForNameAndGetInput(firstOrLastName);
                parse = _passengerValidator.ValidateName(name);
                if (parse == false)
                {
                    _addPassengerScreen.DisplayInvalidName();
                }
            } while (!parse);

            return name;
        }

        public DateTime GetBirthDate()
        {
            string birthDate;
            bool parse;

            do
            {
                birthDate = _addPassengerScreen.AskForBirthDateAndGetInput();
                parse = _passengerValidator.ValidateDate(birthDate);
            } while (!parse);
            return DateTime.Parse(birthDate);
        }
    }
}
