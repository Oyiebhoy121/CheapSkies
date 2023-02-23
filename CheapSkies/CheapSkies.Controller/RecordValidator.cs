using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Validator
{
    public class RecordValidator
    {
        public bool ValidateAirlineCode(string airlineCode)
        {
            int letterCount = 0;
            int digitCount = 0;
            bool validate = false;
            char[] charArray = airlineCode.ToCharArray();
            if(charArray.Length < 2 || charArray.Length> 3)
            {
                return false;
            }
            foreach(char character in charArray) 
            {
                if(char.IsLetter(character))
                {
                    letterCount++;
                }
                if(char.IsDigit(character))
                {
                    digitCount++;
                }
            }
            if(letterCount > 0) { }


            
        }
    }
}
