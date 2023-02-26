using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Model
{
    public class Record
    {
        public Record() { }
        public Record(string airlineCode, int flightNumber, string arrivalStation, string departureStation)
        {
            AirlineCode = airlineCode;
            FlightNumber = flightNumber;
            ArrivalStation = arrivalStation;
            DepartureStation = departureStation;
        }

        public string AirlineCode { get; }
        public int FlightNumber { get; }
        public string ArrivalStation { get; }
        public string DepartureStation { get; }
        
    }
}
