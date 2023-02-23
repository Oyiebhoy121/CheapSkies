namespace CheapSkies.Model
{
    public class Flight : Record
    {
        public TimeSpan ScheduleTimeOfArrival { get; set; }
        public TimeSpan ScheduleTimeOfDeparture { get; set; }

        public Flight(string airlineCode, int flightNumber, string arrivalStation, string departureStation, TimeSpan scheduleTimeOfArrival, TimeSpan scheduleTimeOfDeparture)
            : base(airlineCode, flightNumber, arrivalStation, departureStation)
        {
            ScheduleTimeOfArrival = scheduleTimeOfArrival;
            ScheduleTimeOfDeparture = scheduleTimeOfDeparture;
        }
    }
}