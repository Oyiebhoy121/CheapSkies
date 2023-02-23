using CheapSkies.Interfaces;
using CheapSkies.Model;

namespace CheapSkies.Infrastructure
{
    public class FlightRepository : IRepository<Flight>
    {
        List<Flight> _data { get; set; }

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