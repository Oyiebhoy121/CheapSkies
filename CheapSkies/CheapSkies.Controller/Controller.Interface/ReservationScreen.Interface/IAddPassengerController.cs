using CheapSkies.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller.Interface.ReservationScreen.Interface
{
    public interface IAddPassengerController
    {
        int AddPassengers(Reservation reservation);
    }
}
