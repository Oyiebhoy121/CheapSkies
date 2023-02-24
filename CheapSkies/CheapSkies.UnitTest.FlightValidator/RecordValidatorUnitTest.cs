using CheapSkies.Validator;
using Xunit;

namespace CheapSkies.UnitTest.FlightValidator
{
    public class RecordValidatorUnitTest
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            string airlineCode = "";
            var validator = new RecordValidator();
            //Act
            bool actual = validator.ValidateAirlineCode(airlineCode);
            //Assert
            Assert.False(actual);
        }
    }
}