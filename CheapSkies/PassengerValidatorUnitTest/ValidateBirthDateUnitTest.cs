using CheapSkies.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerValidatorUnitTest
{
    public class ValidateBirthDateUnitTest
    {
        [Fact] //This will fail because I should follow dd/mm/yyyy format
        public void ValidateBirthDateUnitTest1()
        {
            //Arrange
            var sut = new PassengerValidator();
            string date1 = "12/24/2022";
            string date2 = " 12/24/2022 ";
            string date3 = "12/24/2094";
            string date4 = "02/24/2023";
            string date5 = "02-24-2023";
            string date6 = "24-05-2023";
            string date7 = "12-0a-2023";
            //Act
            bool result1 = sut.ValidateBirthDate(date1);
            bool result2 = sut.ValidateBirthDate(date2);
            bool result3 = sut.ValidateBirthDate(date3);
            bool result4 = sut.ValidateBirthDate(date4);
            bool result5 = sut.ValidateBirthDate(date5);
            bool result6 = sut.ValidateBirthDate(date6);
            bool result7 = sut.ValidateBirthDate(date7);
            //Assert
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.True(result4);
            Assert.False(result5);
            Assert.False(result6);
            Assert.False(result7);
        }
    }
}
