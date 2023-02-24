using CheapSkies.Validator;

namespace CheapSkies.Controller
{
    public class FlightValidator : RecordValidator
    {
        public bool ValidateTimeFormat(string timeInput)
        {
            string timeSpanFormat = @"hh\:mm";
            bool parse = TimeSpan.TryParseExact(timeInput, timeSpanFormat, System.Globalization.CultureInfo.InvariantCulture, out TimeSpan result);

            if(parse)
            { 
                return true;
            }
            return false;
        }
      
    }
}