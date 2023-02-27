using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Model.DataModel
{
    public class RecordBase
    {
        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
    }
}
