using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Model.DataModel
{ 
    public class FlightBase : RecordBase
    {
        public string ScheduleTimeOfArrival { get; set; }
        public string ScheduleTimeOfDeparture { get; set; }
    }
}
