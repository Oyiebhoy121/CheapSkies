using CheapSkies.Controller.Controller.FlightMaintenancScreen.Interface;
using CheapSkies.Infrastructure;
using CheapSkies.Model.DataModel;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller.FlightMaintenanceScreen
{

    public class DisplayFlightController : IDisplayFlightController
    {
        private UI _ui = new UI();
        private readonly string[] menu =
        {
            "Searching Flight",
            "\nInput Flight Number (e.g. 1, 124, 9999):",
            "\nSearching by Flight Number",
            "\nNo available flights with the FlightNumber of ",
            "\nInput the Airline Code you want to search (e.g. 5J, TAM, A4C):",
            "\nSearching by Airline Code",
            "\nNo available flights with the Airline Code of ",
            "\nInput the Arrival Station you want to search (e.g. MNL, AB3, NRT):",
            "\nInput the Departure Station you want to search (e.g. MNL, AB3, NRT):",
            "\nSearching by Arrival and Departure Stations",
            "\nNo available flights with the Market Pair of ",
            "\nShowing Flight Results:",
            "\nInvalid Input"
        };

        public void DisplayFlightbyFlightNumber()    
        {
            _ui.Clear();
            _ui.Display(menu[0]);
            _ui.Display(menu[1]);

            string rawFlightNumber = _ui.GetInput();

            bool condition = Int32.TryParse(rawFlightNumber, out int flightNumber);
            if (!condition)
            {
                _ui.Display(menu[12]);
                _ui.ExitScreen();
                return;
            }

            _ui.Display(menu[2]);
            
            //Obtaining Flights from FlightRepository
            FlightRepository flightRepository = new FlightRepository();
            List<FlightBase> listOfFlights = new List<FlightBase>();

            listOfFlights = flightRepository.GetFlightData(flightNumber);
            if (listOfFlights.Count == 0)
            {
                
                _ui.Display(menu[3], flightNumber);
                _ui.ExitScreen();
                return;
            }
            _ui.Display(menu[11]);
            ShowFlights(listOfFlights);
            _ui.ExitScreen();
        }
        public void DisplayFlightByAirlineCode()
        {
            _ui.Clear();
            _ui.Display(menu[0]);
            _ui.Display(menu[4]);
            string airlineCode = _ui.GetInput();

            _ui.Display(menu[5]);
            //Obtaining Flights from FlightRepository
            FlightRepository flightRepository = new FlightRepository();
            List<FlightBase> listOfFlights = new List<FlightBase>();

            listOfFlights = flightRepository.GetFlightData(airlineCode);
            if (listOfFlights.Count == 0)
            {
                _ui.Display(menu[6], airlineCode);
                _ui.ExitScreen();
                return;
            }
            _ui.Display(menu[11]);
            ShowFlights(listOfFlights);
            _ui.ExitScreen();
        }
        public void DisplayFlightByStations()
        {
            _ui.Clear();
            _ui.Display(menu[0]);
            _ui.Display(menu[7]);
            string arrivalStation = _ui.GetInput();
            _ui.Display(menu[8]);
            string departureStation = _ui.GetInput();

            _ui.Display(menu[9]);
            //Obtaining Flights from FlightRepository
            FlightRepository flightRepository = new FlightRepository();
            List<FlightBase> listOfFlights = new List<FlightBase>();

            listOfFlights = flightRepository.GetFlightData(arrivalStation, departureStation);
            if (listOfFlights.Count == 0)
            {
                _ui.Display(menu[10], arrivalStation, departureStation);
                _ui.ExitScreen();
                return;
            }
            _ui.Display(menu[11]);
            ShowFlights(listOfFlights);
            _ui.ExitScreen();
        }
        private void ShowFlights(List<FlightBase> listOfFlights)    //Candidate for Abstraction using Interface IShowList
        {

            _ui.Display("Airline Code \t Flight Number \t Arrival Station \t Departure Station \t Schedule Time of Arrival \t Schedule Time of Departure");
            foreach (FlightBase flight in listOfFlights)
            {
                _ui.Display($"{flight.AirlineCode} \t\t {flight.FlightNumber}\t\t {flight.ArrivalStation}\t\t\t {flight.DepartureStation}\t\t\t {flight.ScheduleTimeOfArrival}\t\t\t\t {flight.ScheduleTimeOfDeparture}");
            }
        }
    }
}
