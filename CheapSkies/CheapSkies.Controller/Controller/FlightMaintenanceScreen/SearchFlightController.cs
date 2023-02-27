using CheapSkies.Controller.Controller.FlightMaintenanceScreen;
using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Model.DataModel;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller.Flight_Maintenance_Screen
{
    public class SearchFlightController
    {
        private readonly string[] menu =
        {
            "Search Flight Screen",
            "Press 1 and enter => Search by Flight Number",
            "Press 2 and enter => Search by Airline Code",
            "Press 3 and enter => Search by Origin and Departure Station",
            "Press 4 and enter => Go Back to Flight Maintenance Screen"
        };
        public void SearchFlight()
        {
            UI ui = new UI();
            DisplayFlightController displayFlightController = new DisplayFlightController();
            string userInput = "";

            while (userInput != "1" || userInput != "2" || userInput != "3")
            {
                ui.Display(menu);
                userInput = ui.GetInput();

                switch (userInput)
                {
                    case "1":
                        //Search by Flight Number
                        break;
                    case "2":
                        //Search by Airline Code 
                        break;
                    case "3":
                        //Search by Origin and Departure Station
                        break;
                    case "4":
                        return;
                    default:
                        break;
                }
            }




















            string userInput;
            bool result;
            int userValidatedInput;
            do
            {
                userInput = _uIScreen.DisplaySearchFlightScreenAndGetInput();
                result = _screenInputValidator.ValidateInput(userInput, 4);
                if(!result)
                {
                    _uIScreen.DisplayInvalidScreenInpuMessage("4");
                }
            } while (! result);

            
            List<FlightBase> flights = new List<FlightBase>();
            switch (userInput)
            {
                case "1":
                    ShowFlightsbyFlightNumber();
                    Console.WriteLine("Press any key to go Back to Home Screen");
                    Console.ReadLine();
                    break;
                case "2":
                    ShowFlightsByAirlineCode();
                    Console.WriteLine("Press any key to go Back to Home Screen");
                    Console.ReadLine();
                    break;
                case "3":
                    ShowFlightsByStations();
                    Console.WriteLine("Press any key to go Back to Home Screen");
                    Console.ReadLine();
                    break;
                case "4":
                    break;
            }
        } 

        private void ShowFlightsbyFlightNumber()
        {
            List<FlightBase> listOfFlight = new List<FlightBase>();
            int flightNumber = _addFlightController.GetFlightNumber();
            listOfFlight = _flightRepository.GetFlightData(flightNumber);

            _searchScreen.DisplayFlightSearchesByFlightNumber(flightNumber);
            _searchScreen.ShowFlights(listOfFlight);

        }

        private void ShowFlightsByAirlineCode()
        {
            List<FlightBase> listOfFlight = new List<FlightBase>();
            string airlineCode = _addFlightController.GetAirlineCode();
            listOfFlight = _flightRepository.GetFlightData(airlineCode);

            _searchScreen.DisplayFlightSearchesByAirLineCode(airlineCode);
            _searchScreen.ShowFlights(listOfFlight);
        }

        private void ShowFlightsByStations()
        {
            List<FlightBase> listOfFlight = new List<FlightBase>();
            string arrivalStation = _addFlightController.GetStation("Arrival");
            string departureStation = _addFlightController.GetStation("Departure");
            listOfFlight = _flightRepository.GetFlightData(arrivalStation, departureStation);

            _searchScreen.DisplayFlightSearchesByStations(arrivalStation, departureStation);
            _searchScreen.ShowFlights(listOfFlight);
        }
    }
}
