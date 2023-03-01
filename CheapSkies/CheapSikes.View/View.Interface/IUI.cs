using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.View.View.Interface
{
    public interface IUI
    {
        void Clear();
        void Display(string[] message);
        void Display(string message);
        void Display(string message, int number);
        void Display(string message, string input);
        void Display(string message, string input1, string input2);
        void Display(Flight flight);
        void Display(FlightBase flightbase);
        void Display(Reservation reservation);
        void Display(ReservationBase reservationBase);
        void Display(Passenger passenger);
        void Display(PassengerBase passengerBase);
        void ExitScreen();;
        string GetInput();
        string DisplayReservationScreenAndGetInput();
    }
}
