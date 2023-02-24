using CheapSkies.Controller;

namespace FlightValidatorUnitTest
{
    public class ValidateTimeFormatUnitTest
    {
        [Fact]
        public void ValidateTimeFormatTest1()
        {
            //Arrange
            var sut = new FlightValidator();
            string timeFormat1 = "00:00";
            string timeFormat2 = "23:59";
            string timeFormat3 = "12:09";
            //Act
            bool result1 = sut.ValidateTimeFormat(timeFormat1);
            bool result2 = sut.ValidateTimeFormat(timeFormat2);
            bool result3 = sut.ValidateTimeFormat(timeFormat3);
            //Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void ValidateTimeFormatTest2()
        {
            //Arrange
            var sut = new FlightValidator();
            string timeFormat1 = "0:00";
            string timeFormat2 = "00:0";
            string timeFormat3 = "-23:59";
            string timeFormat4 = "12:0a";
            string timeFormat5 = "12:00:23";
            string timeFormat6 = "12/00";
            string timeFormat7 = "25:00";
            string timeFormat8 = "";

            //Act
            bool result1 = sut.ValidateTimeFormat(timeFormat1);
            bool result2 = sut.ValidateTimeFormat(timeFormat2);
            bool result3 = sut.ValidateTimeFormat(timeFormat3);
            bool result4 = sut.ValidateTimeFormat(timeFormat4);
            bool result5 = sut.ValidateTimeFormat(timeFormat5);
            bool result6 = sut.ValidateTimeFormat(timeFormat6);
            bool result7 = sut.ValidateTimeFormat(timeFormat7);
            bool result8 = sut.ValidateTimeFormat(timeFormat8);
            //Assert
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
            Assert.False(result5);
            Assert.False(result6);
            Assert.False(result7);
            Assert.False(result8);
        }
    }
}