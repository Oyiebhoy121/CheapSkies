using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;

namespace CheapSkies.View
{
    public class SearchScreen
    {
        public void ShowFlights(List<FlightBase> listOfFlights)
        {
            Console.Clear();
            Console.WriteLine("Showing Flight Results:\n");
            Console.WriteLine("Airline Code \t Flight Number \t Departure Station \t Arrival Station \t" +
                "Schedule Time of Arrival \t Schedule Time of Departure");
            foreach(FlightBase flight in listOfFlights)
            {
                Console.WriteLine($"{flight.AirlineCode}\t" +
                                    $"{flight.FlightNumber}\t" +
                                    $"{flight.DepartureStation}\t" +
                                    $"{flight.ArrivalStation}\t" +
                                    $"{flight.ScheduleTimeOfDeparture}\t" +
                                    $"{flight.ScheduleTimeOfArrival}\t");
            }
        }

        public void ShowReservations(List<ReservationBase> listOfReservations)
        {   
            Console.WriteLine("Showing Reservation Results:\n");
            Console.WriteLine("PNR \t Airline Code \t Flight Number \t Departure Station \t Arrival Station \t" +
                "Flight Date \t Number Of Passengers");
            foreach (ReservationBase reservation in listOfReservations)
            {
                Console.WriteLine($"{reservation.PNR}\t" +
                                    $"{reservation.AirlineCode}\t" +
                                    $"{reservation.FlightNumber}\t" +
                                    $"{reservation.ArrivalStation}\t" +
                                    $"{reservation.DepartureStation}\t" +
                                    $"{reservation.FlightDate}\t" +
                                    $"{reservation.NumberOfPassenger}\t\n\n");
            }
        }

        public void ShowPassengers(List<PassengerBase> listOfPassengers)
        {
            Console.WriteLine("Showing Passenger Results:\n");
            Console.WriteLine("First Nmae \t Last Name \t Birth Date \t Age");
            foreach (PassengerBase passenger in listOfPassengers)
            {
                Console.WriteLine($"{passenger.FirstName}\t" +
                                    $"{passenger.LastName}\t" +
                                    $"{passenger.BirthDate}\t" +
                                    $"{passenger.Age}\t");
            }
        }
        public void DisplaySuccessfullyShowFlights()
        {
            Console.Clear();
            Console.WriteLine("Flights shown above.");
            Console.WriteLine("Press any key to go back Home");
            Console.Read();
        }

        public void DisplayFlightSearchesByFlightNumber(int flightNumber)
        {
            Console.Clear();
            Console.WriteLine($"Showing Flights via FligthNumber {flightNumber}");
        }

        public void DisplayFlightSearchesByAirLineCode(string airlineCode)
        {
            Console.Clear();
            Console.WriteLine($"Showing Flights via FligthNumber {airlineCode}");
        }

        public void DisplayFlightSearchesByStations(string arrivalStation, string departureStation)
        {
            Console.Clear();
            Console.WriteLine($"Showing Flights via Market Pair Stations " +
                                $"{arrivalStation}-{departureStation}:");
        }

        public void DisplayAllReservations()
        {
            Console.Clear();
            Console.WriteLine("Showing all reservations in the system");
        }
        public void DisplayReservationsByPNR(string pnr)
        {
            Console.Clear();
            Console.WriteLine($"Showing all reservations based on PNR {pnr}");
        }

        public void DisplayPassengersByPNR(string pnr)
        {
            Console.Clear();
            Console.WriteLine($"Showing all passsengers based on PNR {pnr}");
        }

        public string AskForPNRAndGetInput()
        {
            Console.WriteLine("Input the 6 Character PNR");
            string input = Console.ReadLine();
            return input;
        }
    }
}
