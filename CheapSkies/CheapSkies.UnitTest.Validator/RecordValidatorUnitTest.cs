using CheapSkies.Validator;

namespace CheapSkies.UnitTest.Validator
{
    public class RecordValidatorUnitTest
    {
        [Fact]
        public void ValidateAirlineCodeTest()
        {
            //Arrange
            string airlineCode = "";
            //Act
            bool actual = ValidateAirlineCode(airlineCode);
            //Assert
            Assert.True(actual);
    }
}
}