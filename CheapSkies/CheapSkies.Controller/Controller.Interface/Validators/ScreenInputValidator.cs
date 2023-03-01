using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller.Interface.Validators
{
    public class ScreenInputValidator
    {
        public bool ValidateInput(string input, int maxOption)
        {
            bool parse = int.TryParse(input, out int value);
            if (parse)
            {
                if (value >= 1 && value <= maxOption)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
