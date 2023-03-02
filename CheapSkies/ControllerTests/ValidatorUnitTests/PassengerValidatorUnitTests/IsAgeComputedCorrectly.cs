using CheapSkies.Controller.Validators;
using CheapSkies.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PassengerValidatorUnitTest
{
    public class IsAgeComputedCorrectly
    {
        [Fact]
        public void CalculateAge_WhenBirthDateIs_ReturnsCorrectAge()
        {
            //Arrange
            var softwareUnderTest = new Passenger("ABCDEF", "Felipe", "Goleta", new DateOnly(1999, 7, 8));

            //Act
            var actualAge = softwareUnderTest.Age;

            //Assert
            Assert.Equal(23, actualAge);
        }

        [Fact]
        public void CalculateAge_WhenBirthDateIsToday_ReturnsCorrectAge()
        {
            //Arrange
            var softwareUnderTest = new Passenger("ABCDEF", "Felipe", "Goleta", new DateOnly(2023, 2, 3));

            //Act
            var actualAge = softwareUnderTest.Age;

            //Assert
            Assert.Equal(0, actualAge);
        }
    }
}
