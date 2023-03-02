using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheapSkies.Controller.Validators.Interface;
using CheapSkies.Infrastructure.Repositories.FlightRepository;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using ValidatorInterface;

namespace CheapSkies.Controller.Validators
{
    public class ReservationValidator : RecordValidator, IReservationValidator
    {
        private IFlightRepository _flightRepository;
        
        public ReservationValidator(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        /// <summary>
        /// Validates if the Flight Date of reservation that inputted by the user follows the format of "MM/dd/yyyy"
        /// and if it is not a past date 
        /// </summary>
        /// <param name="flightDate">Input Flight Date of Reservation by the User for a Reservation</param>
        /// <returns>True if the parameter follows the date format is a present or future date only; otherwise, false.</returns>
        public bool IsFlightDateValid(string flightDate)
        {
            string flightDateFormat = @"MM/dd/yyyy";
            bool parse = DateOnly.TryParseExact(flightDate, flightDateFormat, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateOnly result);

            if (parse)
            {
                TimeSpan timeSpan = DateTime.Parse(flightDate) - DateTime.Today;

                if (timeSpan.TotalMilliseconds >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates if the Number of Passengers reservation is a number between 1 to 5 only
        /// </summary>
        /// <param name="passengerNumber">Input Number of Passengers by the User for a Reservation</param>
        /// <returns>True if the parameter is an int between 1 to 5, including these values; otherwise, false.</returns>
        public bool IsNumberOfPassengersValid(string passengerNumber)
        {
            bool parse = int.TryParse(passengerNumber, out int resultNumber);


            if (parse && passengerNumber.Trim() == passengerNumber)
            {
                if (resultNumber > 0 && resultNumber < 6)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates if the Reservation that the user is trying to create corresponds
        /// to an existing Flight
        /// </summary>
        /// <param name="reservation">Inputted Reservation object by the user</param>
        /// <returns>True if the reservation corresponds to an existing flight; otherwise, false.</returns>
        public bool IsFlightValidForReservation(Reservation reservation)
        {
            List<FlightBase> listOfFlights = _flightRepository
                .GetFlightData()
                .ToList()
                .Where(flight => flight.AirlineCode == reservation.AirlineCode && 
                    flight.FlightNumber == reservation.FlightNumber &&
                    flight.ArrivalStation == reservation.ArrivalStation &&
                    flight.DepartureStation == reservation.DepartureStation)
                .ToList();
            
            if (listOfFlights.Count > 0)
            {
                return true;
            }

            return false;
        }

    }
}
