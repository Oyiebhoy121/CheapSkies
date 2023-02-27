using CheapSkies.Model.DataModel;

namespace CheapSkies.Model.ViewModel
{
    public class Flight : FlightBase
    {
        public string AirlineCode { get; }
        public int FlightNumber { get; }
        public string ArrivalStation { get; }
        public string DepartureStation { get; }
        public TimeSpan ScheduleTimeOfArrival { get; }
        public TimeSpan ScheduleTimeOfDeparture { get; }

        public Flight() { }
        public Flight(string airlineCode, int flightNumber, string arrivalStation, string departureStation, 
            TimeSpan scheduleTimeOfArrival, TimeSpan scheduleTimeOfDeparture)
        {
            AirlineCode = airlineCode;
            FlightNumber = flightNumber;
            ArrivalStation = arrivalStation;
            DepartureStation = departureStation;
            ScheduleTimeOfArrival = scheduleTimeOfArrival;
            ScheduleTimeOfDeparture = scheduleTimeOfDeparture;
        }
    }
}