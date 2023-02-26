using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.View
{
    public class AddReservationScreen : GeneralRecordScreen
    {
        public string AskForFlightDateAndGetInput()
        {
            Console.WriteLine("Input the Flight Date (Format: mm/dd/yyy)");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayInvalidFlightDate()
        {
            Console.WriteLine("Invalid Input. Follow the given format. Make sure that the date is not a past date");
        }

        public string AskForNumberOfPassengersAndGetInput()
        {
            Console.WriteLine("Input the number of passengers you are booking (1-5 passengers only):  ");
            string input = Console.ReadLine();
            return input;
        }

        public void DisplayInvalidNumberOfPassengers()
        {
            Console.Clear();
            Console.WriteLine("Invalid Input. Please select a number from 1 to 5 only")
        }

    }
}
