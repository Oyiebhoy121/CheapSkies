﻿using CheapSkies.Controller.Validators;
using CheapSkies.Infrastructure;
using CheapSkies.Model.DataModel;
using CheapSkies.View;

namespace CheapSkies.Controller.Controller.Flight_Maintenance_Screen
{
    public class SearchFlightController
    {
        private AddFlightScreen _addFlightScreen;
        private FlightValidator _flightValidator;
        private FlightRepository _flightRepository;
        private UIScreen _uIScreen;
        private AddFlightController _addFlightController;
        private ScreenInputValidator _screenInputValidator;
        private SearchScreen _searchScreen;
        public SearchFlightController(AddFlightScreen addFlightScreen, FlightValidator flightValidator,
                                    FlightRepository flightRepository, UIScreen uIScreen, 
                                    AddFlightController addFlightController, ScreenInputValidator screenInputValidator,
                                    SearchScreen searchScreen)
        {
            _addFlightScreen = addFlightScreen;
            _flightValidator = flightValidator;
            _flightRepository = flightRepository;
            _uIScreen = uIScreen;
            _addFlightController = addFlightController;
            _screenInputValidator = screenInputValidator;
            _searchScreen = searchScreen;
        }
        public void SearchFlight()
        {
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
