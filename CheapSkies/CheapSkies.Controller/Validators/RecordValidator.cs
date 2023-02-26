using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Validators
{
    public class RecordValidator
    {
        public bool ValidateAirlineCode(string airlineCode)
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

        public bool ValidateFlightNumber(string flightNumber)
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

        public bool ValidateStation(string station)
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
