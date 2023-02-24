using CheapSkies.Validator;

namespace RecordValidatorUnitTest
{
    public class ValidateAirlineCodeUnitTest
    {
        [Fact]
        public void ValidateAirlineCodeUnitTest1()
        {
            //Arrange
            var sut = new RecordValidator();
            string airlineCode = "";
            //Act
            bool actual = sut.ValidateAirlineCode(airlineCode);
            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateAirlineCodeUnitTest2()
        {
            //Arrange
            var sut = new RecordValidator();
            string airlineCode1 = "M";
            string airlineCode2 = "MN";
            string airlineCode3 = "MNL";
            string airlineCode4 = "MNL1";
            //Act
            bool actual1 = sut.ValidateAirlineCode(airlineCode1);
            bool actual2 = sut.ValidateAirlineCode(airlineCode2);
            bool actual3 = sut.ValidateAirlineCode(airlineCode3);
            bool actual4 = sut.ValidateAirlineCode(airlineCode4);
            //Assert
            Assert.False(actual1);
            Assert.True(actual2);
            Assert.True(actual3);
            Assert.False(actual4);
        }

        [Fact]
        public void ValidateAirlineCodeUnitTest3()
        {
            //Arrange
            var sut = new RecordValidator();
            string airlineCode1 = "5J";
            string airlineCode2 = "G3";
            string airlineCode3 = "A4C";
            string airlineCode4 = "BC3";
            //Act
            bool actual1 = sut.ValidateAirlineCode(airlineCode1);
            bool actual2 = sut.ValidateAirlineCode(airlineCode2);
            bool actual3 = sut.ValidateAirlineCode(airlineCode3);
            bool actual4 = sut.ValidateAirlineCode(airlineCode4);
            //Assert
            Assert.True(actual1);
            Assert.True(actual2);
            Assert.True(actual3);
            Assert.True(actual4);
        }

        [Fact]
        public void ValidateAirlineCodeUnitTest4()
        {
            //Arrange
            var sut = new RecordValidator();
            string airlineCode1 = "5j";
            string airlineCode2 = "g3";
            string airlineCode3 = "A4c";
            string airlineCode4 = "bC3";
            //Act
            bool actual1 = sut.ValidateAirlineCode(airlineCode1);
            bool actual2 = sut.ValidateAirlineCode(airlineCode2);
            bool actual3 = sut.ValidateAirlineCode(airlineCode3);
            bool actual4 = sut.ValidateAirlineCode(airlineCode4);
            //Assert
            Assert.False(actual1);
            Assert.False(actual2);
            Assert.False(actual3);
            Assert.False(actual4);
        }

        [Fact]
        public void ValidateAirlineCodeUnitTest5()
        {
            //Arrange
            var sut = new RecordValidator();
            string airlineCode1 = "5J4";
            string airlineCode2 = "G32";
            string airlineCode3 = "5J&";
            string airlineCode4 = "G*2";
            //Act
            bool actual1 = sut.ValidateAirlineCode(airlineCode1);
            bool actual2 = sut.ValidateAirlineCode(airlineCode2);
            bool actual3 = sut.ValidateAirlineCode(airlineCode3);
            bool actual4 = sut.ValidateAirlineCode(airlineCode4);
            //Assert
            Assert.False(actual1);
            Assert.False(actual2);
            Assert.False(actual3);
            Assert.False(actual4);
        }
    }
}