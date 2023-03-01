using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheapSkies.Infrastructure.Repositories.FlightRepository;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using ValidatorInterface;

namespace CheapSkies.Controller.Controller.Interface.Validators
{
    public class ReservationValidator : RecordValidator, IValidateDate
    {
        public bool ValidateDate(string flightDate)
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

        public bool ValidateNumberOfPassengers(string passengerNumber)
        {
            bool parse = int.TryParse(passengerNumber, out int resultNumber);

            if (parse)
            {
                if (resultNumber > 0 && resultNumber < 6)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateIfReservationHasFlight(Reservation reservation)
        {
            FlightRepository flightRepository = new FlightRepository();
            List<FlightBase> listOfFlights = flightRepository.GetFlightData()
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
