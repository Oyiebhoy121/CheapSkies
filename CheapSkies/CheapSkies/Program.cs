using CheapSkies.Model;
using CheapSkies.Validator;

namespace CheapSkies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sut = new Passenger();
            var dateTime = new DateTime(1999, 7, 8);
            sut.BirthDate = dateTime;
            
            Console.WriteLine($"Age is {sut.Age}");

        }
    }
}