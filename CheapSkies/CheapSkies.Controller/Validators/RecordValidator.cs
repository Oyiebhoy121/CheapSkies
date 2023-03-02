using CheapSkies.Controller.Validators.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Validators
{
    public class RecordValidator : IRecordValidator
    {
        /// <summary>
        /// Validates if the inputted AirLine Code is a 2-3 characters in length and
        /// must be Alphanumeric and capitalized, except for the first character 
        /// which should always be a letter
        /// </summary>
        /// <param name="airlineCode">The inputted Airline of the Flight</param>
        /// <returns>True if airlineCode follows the givevn format; otherwise, false.</returns>
        public bool IsAirlineCodeValid(string airlineCode)
        {
            int capitalLetterCount = 0;
            int digitCount = 0;

            if (airlineCode.Equals(""))
            {
                return false;
            }

            char[] charArray = airlineCode.ToCharArray();

            foreach (char character in charArray)
            {
                if (char.IsLetter(character) && char.ToUpper(character) == character)
                {
                    capitalLetterCount++;
                }

                if (char.IsDigit(character))
                {
                    digitCount++;
                }
            }

            int validCount = capitalLetterCount + digitCount;

            if (charArray.Length > 1 && charArray.Length < 4)
            {
                if (capitalLetterCount >= digitCount && validCount == charArray.Length)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates if the inputted Flight Number is an integer 
        /// between 1 to 9999 
        /// </summary>
        /// <param name="flightNumber">The inputted Airline of the Flight</param>
        /// <returns>True if flightNumber follows the given format; otherwise, false.</returns>
        public bool IsFlightNumberValid(string flightNumber)
        {
            if (flightNumber.Contains(" "))
            {
                return false;
            }

            bool result = int.TryParse(flightNumber, out int value);

            if (value >= 1 && value <= 9999 && result)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validates if the Station Code is always exactly 3 characters and 
        /// should be alphanmeric, except for the first character which should
        /// always be a letter
        /// </summary>
        /// <param name="station">The inputted Arrival or Departure Station of the Flight</param>
        /// <returns>True if station follows the given format; otherwise, false.</returns>
        public bool IsStationValid(string station)
        {
            int validTotal = 0;

            if (station.Equals(""))
            {
                return false;
            }

            char[] charArray = station.ToCharArray();

            foreach (char character in charArray)
            {
                if (char.IsLetter(character) && char.ToUpper(character) == character
                    || char.IsNumber(character))
                {
                    validTotal++;
                }
            }

            if (char.IsLetter(charArray[0]) && validTotal == 3)
            {
                return true;
            }

            return false;
        }
    
    }
}
