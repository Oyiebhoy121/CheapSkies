﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller.Interface.FlightMaintenancScreen.Interface
{
    public interface IDisplayFlightController
    {
        void DisplayFlightbyFlightNumber();
        void DisplayFlightByAirlineCode();
        void DisplayFlightByStations();
    }
}
