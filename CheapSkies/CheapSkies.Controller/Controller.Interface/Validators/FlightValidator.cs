using CheapSkies.Infrastructure;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;

namespace CheapSkies.Controller.Controller.Interface.Validators
{
    public class FlightValidator : RecordValidator
    {
        public bool ValidateTimeFormat(string timeInput)
        {
            string timeSpanFormat = @"hh\:mm";
            bool parse = TimeSpan.TryParseExact(timeInput, timeSpanFormat, System.Globalization.CultureInfo.InvariantCulture, out TimeSpan result);

            if (parse)
            {
                return true;
            }
            return false;
        }

        public bool ValidateIfInputIsDuplicate(Flight flight)
        {
            FlightRepository flightRepository = new FlightRepository();
            List<FlightBase> listOfFlights = new List<FlightBase>();
            listOfFlights = flightRepository.GetFlightData();

            List<FlightBase> listOfDuplicateFlights = new List<FlightBase>();
            listOfDuplicateFlights = listOfFlights.Where(f => f.AirlineCode == flight.AirlineCode &&
                                                            f.FlightNumber == flight.FlightNumber &&
                                                            f.ArrivalStation == flight.ArrivalStation &&
                                                        f.DepartureStation == flight.DepartureStation).ToList();

            if (listOfDuplicateFlights.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}