using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Model
{
    public class Reservation : Record
    {
        public Reservation(string airlineCode, int flightNumber, string arrivalStation, string departureStation, DateTime flightDate, int numberOfPassenger)
            : base(airlineCode, flightNumber, arrivalStation, departureStation)
        {
            FlightDate = flightDate;
            NumberOfPassenger = numberOfPassenger;
        }

        public DateTime FlightDate { get; set; }
        public int NumberOfPassenger { get; set; }

    }
}
