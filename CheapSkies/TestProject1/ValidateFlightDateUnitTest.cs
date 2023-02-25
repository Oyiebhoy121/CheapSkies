using CheapSkies.Validator;

namespace TestProject1
{
    public class ValidateFlightDateUnitTest
    {
        [Fact]
        public void ValidateFlightDateUnitTest1()
        {
            var sut = new ReservationValidator();
            string date1 = "02/25/2023";
            string date2 = "02/25/2024";
            string date3 = "02/25/2022";

            //Act
            bool result1 = sut.ValidateDate(date1);
            bool result2 = sut.ValidateDate(date2);
            bool result3 = sut.ValidateDate(date3);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
        }
    }
}