using CheapSkies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerUnitTest
{
    public class ValidateAgeUnitTest
    {
        [Fact]
        public void ValidateAgeUnitTest1()
        {
            //Arrange
            var sut = new Passenger();
            DateTime dateTime = new DateTime(1999, 7, 8);
            sut.BirthDate = dateTime;
            //Act

            //Assert
            Assert.Equal(23, sut.Age);
        }

        [Fact]
        public void ValidateAgeUnitTest2()
        {
            //Arrange
            var sut = new Passenger();
            DateTime dateTime = new DateTime(2023, 2, 25);
            sut.BirthDate = dateTime;
            //Act

            //Assert
            Assert.Equal(0, sut.Age);
        }

        [Fact]
        public void ValidateAgeUnitTest3()
        {
            //Arrange
            var sut = new Passenger();
            DateTime dateTime = new DateTime(2024, 3, 3);
            //Act

            //Assert
            var message = Assert.Throws<ArgumentException>(() => sut.BirthDate = dateTime);
            Assert.Equal("Birth date cannot be in the future", message.Message);
        }
    }
}
