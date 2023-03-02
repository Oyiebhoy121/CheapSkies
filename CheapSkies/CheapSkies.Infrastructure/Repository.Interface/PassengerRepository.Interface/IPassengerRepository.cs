using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Infrastructure.Repository.Interface.PassengerRepository.Interface
{
    public interface IPassengerRepository
    {
        void SavePassenger(Passenger passenger);
        void SavePassenger(List<Passenger> listOfPassengers);
        List<PassengerBase> GetPassengerData(string PNR);

    }
}
