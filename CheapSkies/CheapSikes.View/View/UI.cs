using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using CheapSkies.View.View.Interface;
using System.Security.Cryptography;

namespace CheapSkies.View.View
{
    public class UI : IUI
    {
        public void Clear()
        {
            Console.Clear();
        }
        public void Display(string[] message)
        {
            foreach (string m in message)
            {
                Console.WriteLine(m);
            }
        }
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
        public void Display(string message, int number)
        {
            Console.WriteLine(message + number);
        }
        public void Display(string message, string input)
        {
            Console.WriteLine(message + input);
        }
        public void Display(string message, string input1, string input2)
        {
            Console.WriteLine(message + input1 + "-" + input2);
        }
        public void ExitScreen()
        {
            Console.WriteLine("\n\nPress anything to go back Home");
            Console.Read();
        }
        public string GetInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
    
        public void Display(FlightBase flight)
        {
            Console.WriteLine($"{flight.AirlineCode} \t\t {flight.FlightNumber}\t\t {flight.ArrivalStation}\t\t\t {flight.DepartureStation}\t\t\t {flight.ScheduleTimeOfArrival}\t\t\t\t {flight.ScheduleTimeOfDeparture}");
        }

        public void Display(Reservation reservation)
        {
            Console.WriteLine($"{reservation.AirlineCode} \t\t {reservation.FlightNumber} \t\t {reservation.ArrivalStation} \t\t\t " +
                            $"{reservation.DepartureStation} \t\t\t {reservation.FlightDate} \t {reservation.NumberOfPassenger}");
        }

        public void Display(ReservationBase reservationBase)
        {
            throw new NotImplementedException();
        }

        public void Display(Passenger passenger, int passengerCount)
        {
            Console.WriteLine($"\t\t{passengerCount + 1} \t\t\t {passenger.FirstName} \t {passenger.LastName} \t {passenger.BirthDate} \t {passenger.Age}\n");
        }

        public void Display(PassengerBase passenger, int passengerCount)
        {
            Console.WriteLine($"\t\t{passengerCount + 1} \t\t\t {passenger.FirstName} \t {passenger.LastName} \t {passenger.BirthDate} \t {passenger.Age}\n");
        }
    }
}
