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

        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
        
    }
}
