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

            foreach (char character in charArray)
            {
                if (! (char.IsLetter(character) || character.Equals(' ')) ) 
                {
                    return false;
                }
            }
            return true;
        }
    }
}
