using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface
{
    public interface IFlightRepository
    {
        void SaveFlight(Flight flight);
        List<FlightBase> GetFlightData();
        List<FlightBase> GetFlightData(int flightNumber);
        List<FlightBase> GetFlightData(string airlineCode);
        List<FlightBase> GetFlightData(string arrivalStation, string departureStation);

    }
}
