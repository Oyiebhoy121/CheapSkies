using CheapSkies.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordValidatorUnitTest
{
    public class ValidateStation
    {
        [Fact]
        public void ValidateStationTest1()
        {
            //Arrange
            var sut = new RecordValidator();
            string station1 = "MNL";
            string station2 = "MNLO";
            string station3 = "LO";
            string station4 = "O";

            //Act
            bool actual1 = sut.ValidateStation(station1);
            bool actual2 = sut.ValidateStation(station2);
            bool actual3 = sut.ValidateStation(station3);
            bool actual4 = sut.ValidateStation(station4);

            //Assert
            Assert.True(actual1);
            Assert.False(actual2);
            Assert.False(actual3);
            Assert.False(actual4);
        }

        [Fact]
        public void ValidateStationTest2()
        {
            //Arrange
            var sut = new RecordValidator();
            string station1 = "";
   
            //Act
            bool actual1 = sut.ValidateStation(station1);

            //Assert
            Assert.False(actual1);
        }

        [Fact]
        public void ValidateStationTest3()
        {
            //Arrange
            var sut = new RecordValidator();
            string station1 = "MNL";
            string station2 = "NRT";
            string station3 = "AB3";
            string station4 = "B2C";
            string station5 = "X23";

            //Act
            bool actual1 = sut.ValidateStation(station1);
            bool actual2 = sut.ValidateStation(station2);
            bool actual3 = sut.ValidateStation(station3);
            bool actual4 = sut.ValidateStation(station4);
            bool actual5 = sut.ValidateStation(station5);

            //Assert
            Assert.True(actual1);
            Assert.True(actual2);
            Assert.True(actual3);
            Assert.True(actual4);
            Assert.True(actual5);
        }

        [Fact]
        public void ValidateStationTest4()
        {
            //Arrange
            var sut = new RecordValidator();
            string station1 = "M&N";
            string station2 = " RT";
            string station3 = "A  ";
            string station4 = "1BC";

            //Act
            bool actual1 = sut.ValidateStation(station1);
            bool actual2 = sut.ValidateStation(station2);
            bool actual3 = sut.ValidateStation(station3);
            bool actual4 = sut.ValidateStation(station4);

            //Assert
            Assert.False(actual1);
            Assert.False(actual2);
            Assert.False(actual3);
            Assert.False(actual4);
        }
    }
}
