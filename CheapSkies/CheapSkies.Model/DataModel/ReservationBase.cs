using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Model.DataModel
{
    public class ReservationBase : RecordBase
    { 
        public DateOnly FlightDate { get; set; }
        public int NumberOfPassenger { get; set; }
        public string PNR { get; set; }
     
    }
}

