using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidatorInterface;

namespace CheapSkies.Controller.Validators
{
    public class PassengerValidator : IValidateDate
    {
        public bool ValidateName(string name)
        {
            char[] charArray = name.ToCharArray();

            if (name.Equals("") || charArray.Length > 20)
            {
                return false;
            }

            if (name.Trim() != name)
            {
                return false;
            }

            foreach (char character in charArray)
            {
                if (!(char.IsLetter(character) || character.Equals(' ')))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateDate(string birthDate)
        {
            string birthDateFormat = @"MM/dd/yyyy";
            bool parse = DateOnly.TryParseExact(birthDate, birthDateFormat, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateOnly result);

            if (parse)
            {
                TimeSpan timeSpan = DateTime.Today - DateTime.Parse(birthDate);
                if (timeSpan.TotalMilliseconds >= 0)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
