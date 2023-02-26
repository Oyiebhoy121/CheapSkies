using CheapSkies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.View
{
    public class SearchScreen
    {
        public void ShowFlights(List<Flight> listOfFlights)
        {
            Console.Clear();
            Console.WriteLine("Showing Flight Results:\n");
            Console.WriteLine("Airline Code \t Flight Number \t Departure Station \t Arrival Station \t" +
                "Schedule Time of Arrival \t Schedule Time of Departure");
            foreach(Flight flight in listOfFlights)
            {
                Console.WriteLine($"{flight.AirlineCode}\t" +
                                    $"{flight.FlightNumber}\t" +
                                    $"{flight.DepartureStation}\t" +
                                    $"{flight.ArrivalStation}\t" +
                                    $"{flight.ScheduleTimeOfDeparture}\t" +
                                    $"{flight.ScheduleTimeOfArrival}\t");
            }
        }

        public void ShowReservations(List<Reservation> listOfReservations)
        {
            Console.Clear();
            Console.WriteLine("Showing Reservation Results:\n");
            Console.WriteLine("PNR \t Airline Code \t Flight Number \t Departure Station \t Arrival Station \t" +
                "Flight Date \t Number Of Passengers");
            foreach (Reservation reservation in listOfReservations)
            {
                Console.WriteLine($"{reservation.PNR}\t" +
                                    $"{reservation.AirlineCode}\t" +
                                    $"{reservation.FlightNumber}\t" +
                                    $"{reservation.ArrivalStation}\t" +
                                    $"{reservation.DepartureStation}\t" +
                                    $"{reservation.FlightDate}\t" +
                                    $"{reservation.NumberOfPassenger}\t");
            }
        }

        public void ShowPassengers(List<Passenger> listOfPassengers)
        {
            Console.Clear();
            Console.WriteLine("Showing Passenger Results:\n");
            Console.WriteLine("First Nmae \t Last Name \t Birth Date \t Age");
            foreach (Passenger passenger in listOfPassengers)
            {
                Console.WriteLine($"{passenger.FirstName}\t" +
                                    $"{passenger.LastName}\t" +
                                    $"{passenger.BirthDate}\t" +
                                    $"{passenger.Age}\t");
            }

        }
    }
}
