using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidatorInterface;

namespace CheapSkies.Validator
{
    public class ReservationValidator : RecordValidator, IValidateDate
    {
        public bool ValidateDate(string flightDate)
        {
            string flightDateFormat = @"MM/dd/yyyy";
            bool parse = DateTime.TryParseExact(flightDate, flightDateFormat, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime result);

            if (parse)
            {
                TimeSpan timeSpan = result - DateTime.Today;
                if (timeSpan.TotalMilliseconds >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidatePassengerNumber(string passengerNumber)
        {
            bool parse = Int32.TryParse(passengerNumber, out int resultNumber);

            if (parse)
            {
                if (resultNumber > 0 && resultNumber < 6)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
