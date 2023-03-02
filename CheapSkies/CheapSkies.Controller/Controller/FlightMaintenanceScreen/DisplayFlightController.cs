using CheapSkies.Controller.Controller.Interface.FlightMaintenancScreen.Interface;
using CheapSkies.Infrastructure.Repositories.FlightRepository;
using CheapSkies.Infrastructure.RepositoryInterface.FlightRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.View.View;
using CheapSkies.View.View.Interface;

namespace CheapSkies.Controller.Controller.FlightMaintenanceScreen
{
    public class DisplayFlightController : IDisplayFlightController
    {
        private IFlightRepository _flightRepository;
        private IUserInterface _userInterface;

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
            "\nInvalid Input",
            "Airline Code \t Flight Number \t Arrival Station \t Departure Station \t Schedule Time of Arrival \t Schedule Time of Departure"
        };

        public DisplayFlightController(IFlightRepository flightRepository, IUserInterface userInterface)
        {
            _flightRepository = flightRepository;
            _userInterface = userInterface;
        }

        /// <summary>
        /// This will prompt the user to input a Flight Number and Flights 
        /// with the corresponding Flight Number will be shown in the Console
        /// </summary>
        public void DisplayFlightbyFlightNumber()       
        {
            _userInterface.Clear();
            _userInterface.Display(menu[0]);
            _userInterface.Display(menu[1]);
            string rawFlightNumber = _userInterface.GetInput();

            bool condition = Int32.TryParse(rawFlightNumber, out int flightNumber);

            if (!condition)
            {
                _userInterface.Display(menu[12]);
                _userInterface.ExitScreen();

                return;
            }

            _userInterface.Display(menu[2]);
            List<FlightBase> listOfFlights = new List<FlightBase>();
            listOfFlights = _flightRepository.GetFlightData(flightNumber);

            if (listOfFlights.Count == 0)
            {

                _userInterface.Display(menu[3], flightNumber);
                _userInterface.ExitScreen();

                return;
            }

            _userInterface.Display(menu[11]);
            ShowFlights(listOfFlights);
            _userInterface.ExitScreen();
        }

        /// <summary>
        /// This will prompt the user to input an Airline Code and Flights 
        /// with the corresponding Airline Code  will be shown in the Console
        /// </summary>
        public void DisplayFlightByAirlineCode()
        {
            _userInterface.Clear();
            _userInterface.Display(menu[0]);
            _userInterface.Display(menu[4]);
            string airlineCode = _userInterface.GetInput();
            _userInterface.Display(menu[5]);

            List<FlightBase> listOfFlights = new List<FlightBase>();
            listOfFlights = _flightRepository.GetFlightData(airlineCode);

            if (listOfFlights.Count == 0)
            {
                _userInterface.Display(menu[6], airlineCode);
                _userInterface.ExitScreen();

                return;
            }

            _userInterface.Display(menu[11]);
            ShowFlights(listOfFlights);
            _userInterface.ExitScreen();
        }

        /// <summary>
        /// This will prompt the user to input the Arrival Station and Departure Station
        /// and Flights with the corresponding Stations will be shown in the Console
        /// </summary>
        public void DisplayFlightByStations()
        {
            _userInterface.Clear();
            _userInterface.Display(menu[0]);
            _userInterface.Display(menu[7]);
            string arrivalStation = _userInterface.GetInput();
            _userInterface.Display(menu[8]);
            string departureStation = _userInterface.GetInput();
            _userInterface.Display(menu[9]);

            List<FlightBase> listOfFlights = new List<FlightBase>();
            listOfFlights = _flightRepository.GetFlightData(arrivalStation, departureStation);

            if (listOfFlights.Count == 0)
            {
                _userInterface.Display(menu[10], arrivalStation, departureStation);
                _userInterface.ExitScreen();

                return;
            }

            _userInterface.Display(menu[11]);
            ShowFlights(listOfFlights);
            _userInterface.ExitScreen();
        }

        /// <summary>
        /// Displays the List of Flights and its properties in Console
        /// </summary>
        private void ShowFlights(List<FlightBase> listOfFlights)    //Candidate for Abstraction using Interface IShowList
        {
            _userInterface.Display(menu[13]);
            foreach (FlightBase flight in listOfFlights)
            {
                _userInterface.Display(flight);
            }
        }

    }
}
