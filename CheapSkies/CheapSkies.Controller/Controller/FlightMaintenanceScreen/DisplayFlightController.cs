using CheapSkies.Infrastructure;
using CheapSkies.Model.DataModel;
using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller.FlightMaintenanceScreen
{
    public class DisplayFlightController
    {
        private readonly string[] menu =
        {
            "Searching Flight",
            "\nInput Flight Number (e.g. 1, 124, 9999):",
            "\nSearching by Flight Number: ",
            "\nInput the Airline Code you want to search (e.g. 5J, TAM, A4C):",
            "\nSearching by Airline Code ",
            "\nInput the Arrival Station you want to search (e.g. MNL, AB3, NRT):",
            "\nInput the Departure Station you want to search (e.g. MNL, AB3, NRT):",
            "\nSearching by Arrival and Departure Stations",
            "\nShowing Flight Results:",
            "\nInvalid Input"
        };

        public void DisplayFlightbyFlightNumber()
        {
            UI ui = new UI();
            ui.Clear();
            ui.Display(menu[0]);
            ui.Display(menu[1]);
            string rawFlightNumber = ui.GetInput();

            bool condition = Int32.TryParse(rawFlightNumber, out int flightNumber);
            if (condition)
            {
                ui.Display(menu[9]);
                return;
            }
            else


            //Obtaining Flights from FlightRepository
            FlightRepository flightRepository = new FlightRepository();
            List<FlightBase> listOfFlights = new List<FlightBase>();

            listOfFlights = flightRepository.GetFlightData();
            
        }
    }
}
