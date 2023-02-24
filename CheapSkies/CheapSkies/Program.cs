using CheapSkies.Validator;

namespace CheapSkies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var validator = new RecordValidator();
            string airlineCode1 = "5J";
            string airlineCode2 = "G3";
            string airlineCode3 = "A4C";
            string airlineCode4 = "BC3";
            //Act
            bool actual1 = validator.ValidateAirlineCode(airlineCode1);
            bool actual2 = validator.ValidateAirlineCode(airlineCode2);
            bool actual3 = validator.ValidateAirlineCode(airlineCode3);
            bool actual4 = validator.ValidateAirlineCode(airlineCode4);
            //Assert
            Console.WriteLine(actual1);
            Console.WriteLine(actual1);
            Console.WriteLine(actual1);
            Console.WriteLine(actual1);

        }
    }
}