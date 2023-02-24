using CheapSkies.Validator;

namespace ValidateAirlineCodeUnitTest
{
    public class ValidateFlightNumberUnitTest
    {
        [Fact]
        public void ValidateFlightNumberUnitTest1()
        {
            //Arrange
            var validator = new RecordValidator();
            string flightNumber1 = "125";
            string flightNumber2 = "1";
            string flightNumber3 = "9999";
            //Act
            bool actual1 = validator.ValidateFlightNumber(flightNumber1);
            bool actual2 = validator.ValidateFlightNumber(flightNumber2);
            bool actual3 = validator.ValidateFlightNumber(flightNumber3);
            //Assert
            Assert.True(actual1);
            Assert.True(actual2);
            Assert.True(actual3);
        }

        [Fact]
        public void ValidateFlightNumberUnitTest2()
        {
            //Arrange
            var validator = new RecordValidator();
            string flightNumber = "";
            //Act
            bool actual = validator.ValidateFlightNumber(flightNumber);
            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateFlightNumberUnitTest3()
        {
            //Arrange
            var validator = new RecordValidator();
            string flightNumber1 = "125&";
            string flightNumber2 = "1abc";
            string flightNumber3 = "9999 ";
            string flightNumber4 = "12.5";
            //Act
            bool actual1 = validator.ValidateFlightNumber(flightNumber1);
            bool actual2 = validator.ValidateFlightNumber(flightNumber2);
            bool actual3 = validator.ValidateFlightNumber(flightNumber3);
            bool actual4 = validator.ValidateFlightNumber(flightNumber4);
            //Assert
            Assert.False(actual1);
            Assert.False(actual2);
            Assert.False(actual3);
            Assert.False(actual4);
        }

    }
}