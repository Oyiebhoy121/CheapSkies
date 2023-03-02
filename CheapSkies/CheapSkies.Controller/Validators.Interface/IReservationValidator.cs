using CheapSkies.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Validators.Interface
{
    public interface IReservationValidator
    {
        bool IsFlightDateValid(string flightDate);
        bool IsNumberOfPassengersValid(string passengerNumber);
        bool IsFlightValidForReservation(Reservation reservation);
    }
}
