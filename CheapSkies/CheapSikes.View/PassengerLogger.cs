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
            Console.WriteLine("Input Passenger's First Name");
            Console.WriteLine("Do not include suffixes");
            string result = Console.ReadLine();
            return result;
        }

        public string InputLastName()
        {
            Console.WriteLine("Input Passenger's Last Name: ");
            string result = Console.ReadLine();
            return result;
        }

        public string InputBirthDate()
        {
            Console.WriteLine("Input Passenger's BirthDate: ");
            string result = Console.ReadLine();
            return result;
        }

        public string NumberOfPassenger()
        {
            Console.WriteLine("Input the number of passengers you are booking: ");
            string result = Console.ReadLine();
            return result;
        }  
    }
}
