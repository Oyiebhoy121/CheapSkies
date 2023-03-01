using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IGetValidatedInput
    {
        string GetValidatInput(string message1, string message2, Func<string, bool> validator);
    }
}
