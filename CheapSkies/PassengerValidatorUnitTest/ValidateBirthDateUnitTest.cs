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
        [Fact] 
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
            bool result1 = sut.ValidateDate(date1);
            bool result2 = sut.ValidateDate(date2);
            bool result3 = sut.ValidateDate(date3);
            bool result4 = sut.ValidateDate(date4);
            bool result5 = sut.ValidateDate(date5);
            bool result6 = sut.ValidateDate(date6);
            bool result7 = sut.ValidateDate(date7);
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
