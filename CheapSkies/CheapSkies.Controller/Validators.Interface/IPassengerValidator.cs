using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Validators.Interface
{
    public interface IPassengerValidator
    {
        bool IsNameValid(string name);
        bool IsBirthDateValid(string birthDate);
    }
}
