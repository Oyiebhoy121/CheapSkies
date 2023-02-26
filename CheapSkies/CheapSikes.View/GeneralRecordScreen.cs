﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.View
{
    public class GeneralRecordScreen
    {
        public string AskForAirlineCodeMessageAndGetInput()
        {
            Console.WriteLine("Input the Airline Code (e.g. 5J, TAM, A4C): ");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayInvalidAirlineCodeMessage()
        {
            Console.Clear();
            Console.WriteLine("Invalid Input. The input must be 2-3 Uppercased Alphanumberic Code. " +
                "Numeric Character must only appear once.");
        }

        public string AskForFlightNumberMessageAndGetInput()
        {
            Console.WriteLine("Input Flight Number (e.g. 1, 124, 9999): ");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayInvalidFlightNumberMessage()
        {
            Console.Clear();
            Console.WriteLine("Invalid Input. The input must be an an integer between 1-9999");
        }

        public string AskForStationMessageAndGetInput(string arrivalOrDepartureStation)
        {
            Console.WriteLine($"Input {arrivalOrDepartureStation} Station (e.g. MNL, AB3, NRT): ");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayInvalidStation()
        {
            Console.Clear();
            Console.WriteLine("Invalid Input. The input must be exaclty 3 Uppercased Alphanumberic Code. " +
                "Numeric Characters are optional. First character must be a letter");
        }
    }
}
