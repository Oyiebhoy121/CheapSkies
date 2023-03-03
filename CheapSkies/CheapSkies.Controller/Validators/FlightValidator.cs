using CheapSkies.Controller.Validators.Interface;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;

namespace CheapSkies.Controller.Validators
{
    public class FlightValidator : RecordValidator, IFlightValidator
    {
        private IFlightRepository _flightRepository;

        public FlightValidator(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        /// <summary>
        /// Validates if the Schedule Time of Arrival or Departure inputted by the user follows the format of "hh:mm"    
        /// </summary>
        /// <param name="timeInput">Input Schedule Time of Arrival or Departure of Flights by the User</param>
        /// <returns>True if the parameter follows the time format; otherwise, false.</returns>
        public bool IsTimeFormatValid(string timeInput)
        {
            string timeSpanFormat = @"hh\:mm";
            bool parse = TimeSpan.TryParseExact(timeInput, timeSpanFormat, System.Globalization.CultureInfo.InvariantCulture, out TimeSpan result);

            if (parse)
            {
                return true; 
            }

            return false;
        }

        /// <summary>
        /// Validates if the Flight that the user is trying to create is already in the Flight Repository
        /// </summary>
        /// <param name="flight">The flight that the user is attempting to create</param>
        /// <returns>True if the input flight is not already in the Flight Repository; otherwise, false.</returns>
        public bool IsFlightDuplicate(Flight flight)
        {
            List<FlightBase> listOfFlights = new List<FlightBase>();
            listOfFlights = _flightRepository.GetFlightData();

            List<FlightBase> listOfDuplicateFlights = new List<FlightBase>();
            listOfDuplicateFlights = listOfFlights.Where(f => f.AirlineCode == flight.AirlineCode &&
                    f.FlightNumber == flight.FlightNumber &&
                    f.ArrivalStation == flight.ArrivalStation &&
                    f.DepartureStation == flight.DepartureStation).
                ToList();

            if (listOfDuplicateFlights.Count == 0)
            {
                return false;
            }

            return true;
        }

        public bool IsStationDuplicate(string arrivalStation, string departureStation)
        {
            if(arrivalStation == departureStation)
            {
                return true;
            }

            return false;
        }

    }
}