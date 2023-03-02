using CheapSkies.Controller.Validators.Interface;
using ValidatorInterface;

namespace CheapSkies.Controller.Validators
{
    public class PassengerValidator : IPassengerValidator, IValidateDate
    {
        /// <summary>
        /// Validates if the First or Last Name that the user is trying to create for a passenger
        /// is not empty and is less than or equal to 20 characters only 
        /// </summary>
        /// <param name="name">The inputted First or Last Name of the passenger</param>
        /// <returns>True if the input name contains only of letters between 1-20 characters ; otherwise, false.</returns>
        public bool IsNameValid(string name)
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

        /// <summary>
        /// Validates if the inputted Birth Date follows the format of MM/dd/yyyy 
        /// and must be a past date
        /// </summary>
        /// <param name="birthDate">The inputted Birth Date of the passenger</param>
        /// <returns>True if birthDate follows the format and is not a future date ; otherwise, false.</returns>
        public bool IsBirthDateValid(string birthDate)
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
