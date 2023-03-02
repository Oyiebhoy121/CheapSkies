using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Validators.Interface
{
    public interface IRecordValidator
    {
        bool IsAirlineCodeValid(string airlineCode);
        bool IsFlightNumberValid(string flightNumber);
        bool IsStationValid(string station);

    }
}
