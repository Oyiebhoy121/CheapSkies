using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSikes.View
{
    public class PassengerLogger 
    {
        public string InputFirstName()
        {
            Console.WriteLine("Input Passenger's First Name: ");
            string result = Console.ReadLine();
            return result;
        }

        public string InputLastName()
        {
            Console.WriteLine("Input Passenger's Last Name: ");
            string result = Console.ReadLine();
            return result;
        }

        public string BirthDate()
        {
            Console.WriteLine("Input Passenger's BirthDate: ");
            string result = Console.ReadLine();
            return result;
        }
    }
}
