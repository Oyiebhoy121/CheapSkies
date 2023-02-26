using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller
{
    public class MainController
    {
        private Screen _screen;
        public MainController(Screen screen)
        {
            _screen = screen;
        }

        public void Main(string[] args)
        {
            string decision;
            string decision2;
            string decision3;

            do
            {
                decision = _screen.DisplayHomeScreenAndGetInput();
                switch (decision)
                {
                    case "1":
                        decision2 = _screen.DisplayFlightMaintenanceScreenAndGetInput();
                        switch (decision2)
                        {
                            case "1": //Adding Flight
                                break;
                            case "2": //Searching Flight
                                break;
                            case "3":
                                break; //Go Back to Home Screen
                            default:
                                break;
                        }
                        break;
                    case "2":
                        decision2 = _screen.DisplayReservationScreenAndGetInput();
                        break;
                    case "3":
                        return;
                    default:
                        break;
                }
            } while (decision != "3");
        }

        public void AddFlight()
        {

        }
    }
}
