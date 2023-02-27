using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Model.DataModel
{ 
    public class FlightBase : RecordBase
    {
        public TimeSpan ScheduleTimeOfArrival { get; set; }
        public TimeSpan ScheduleTimeOfDeparture { get; set; }
    }
}
