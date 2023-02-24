using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Validator
{
    public class PassengerValidator
    {
        public bool ValidateName(string name)
        {
            char[] charArray = name.ToCharArray();

            if (name.Equals("") || charArray.Length > 20) {
                return false;
            }

            if (name.Trim() != name)
            {
                return false;
            }

            foreach (char character in charArray)
            {
                if (! (char.IsLetter(character) || character.Equals(' '))) 
                {
                    return false;
                }
            }
            return true;
        }
    
        public bool ValidateBirthDate(string birthDate)
        {
            string birthDateFormat = @"mm/dd/yyyy";
            bool parse = DateTime.TryParseExact(birthDate, birthDateFormat, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime result);
            
            if (parse)
            {
                TimeSpan timeSpan = DateTime.Today - result;
                if(timeSpan.TotalMilliseconds > 0)
                {
                    return true;
                }
            }
            return false;
        }
    
        //I'm still not sure about this because I must create an AgeComputer(DateTime BirthDate) for the Passenger
        public bool ValidateAge(int ageComputed, DateTime birthDate)
        {
            TimeSpan timeSpanAge = DateTime.Today - birthDate;
            int actualAge = (int) (timeSpanAge.TotalDays / 365.25);
            if(ageComputed == actualAge)
            {
                return true;
            }
            return false;
        }
        public bool ValidatePassengerNumber(string passengerNumber)
        {
            bool parse = Int32.TryParse(passengerNumber, out int resultNumber);

            if(parse)
            {
                if(resultNumber > 0 && resultNumber < 6)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
