﻿using CheapSkies.Validator;
using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSikes.View
{
    public class PassengerLogger 
    {
        private PassengerValidator _passengerValidator;
        public PassengerLogger(PassengerValidator passengerValidator) 
        {
            _passengerValidator = passengerValidator;
        }

        public string InputName(int nameNumber)
        {
            string result;
            string firstOrLastName;
            bool condition;

            switch (nameNumber)
            {
                case 1:
                    firstOrLastName = "First";
                    break;
                case 2:
                    firstOrLastName = "Last";
                    break;
                default:
                    throw new ArgumentException("Name Number Input is invalid", nameof(nameNumber));
            }

            do
            {
                Console.WriteLine($"Input the {firstOrLastName} Name of the Passenger (e.g. John, Smith): ");
                result = Console.ReadLine();
                condition = _passengerValidator.ValidateName(result);

                if (condition == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. The input must be composed of 1-20 Characters only. " +
                        "Letters and spaces only.");
                }
            } while (!condition);

            return result;
        }

        public DateTime InputBirthDate()
        {
            string result;
            bool condition;

            do
            {
                Console.WriteLine("Input Passenger's BirthDate (Format: mm/dd/yyyy): ");
                result = Console.ReadLine();
                condition = _passengerValidator.ValidateDate(result);

                if (condition == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Follow the given format. Make sure that the date is not a future date");
                }
            } while (!condition);


            return DateTime.ParseExact(result, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture );
        }

        
    }
}
