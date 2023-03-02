using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Infrastructure.RepositoryInterface.ReservationRepository.Interface
{
    public interface IReservationRepository
    {
        void SaveReservation(Reservation reservation);
        List<ReservationBase> GetReservationData();
        List<ReservationBase> GetReservationData(string PNR);
        List<string> GetPNRData();
    }
}
