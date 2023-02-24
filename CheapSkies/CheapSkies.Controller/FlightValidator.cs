using CheapSkies.Validator;

namespace CheapSkies.Controller
{
    public class FlightValidator : RecordValidator
    {
        public bool ValidateTimeFormat(string timeInput)
        {
            string format = @"hh\:mm";
            bool parse = TimeSpan.TryParseExact(timeInput, format, System.Globalization.CultureInfo.InvariantCulture, out TimeSpan result);

            if(parse)
            { 
                return true;
            }
            return false;
        }
      
    }
}