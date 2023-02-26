using CheapSkies.Interfaces;
using CheapSkies.Model;

namespace CheapSkies.Infrastructure
{
    public class FlightRepository : IRepository<Flight>
    {
        List<Flight> _data { get; set; }
        List<Flight> IRepository<Flight>._data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public FlightRepository() 
        {
            
        }
        public void Add(Flight flight)
        {

        }
        public void Fetch(Flight flight)
        {

        }

    }
}