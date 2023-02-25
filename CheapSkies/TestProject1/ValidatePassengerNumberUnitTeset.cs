using CheapSkies.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationValidatorUnitTest
{
    public class ValidatePassengerNumberUnitTeset
    {
        using CheapSkies.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerValidatorUnitTest
    {
        public class ValidatePassengerNumberUnitTest
        {
            [Fact]
            public void ValidatePassengerNumberUnitTest1()
            {
                //Arrange
                var sut = new ReservationValidator();
                string number1 = "0";
                string number2 = "1";
                string number3 = "5";
                string number4 = "6";
                string number5 = " 6 ";
                string number6 = "4a";
                string number7 = "-4";
                string number8 = "4.25";
                //Act
                bool result1 = sut.ValidatePassengerNumber(number1);
                bool result2 = sut.ValidatePassengerNumber(number2);
                bool result3 = sut.ValidatePassengerNumber(number3);
                bool result4 = sut.ValidatePassengerNumber(number4);
                bool result5 = sut.ValidatePassengerNumber(number5);
                bool result6 = sut.ValidatePassengerNumber(number6);
                bool result7 = sut.ValidatePassengerNumber(number7);
                bool result8 = sut.ValidatePassengerNumber(number8);
                //Assert
                Assert.False(result1);
                Assert.True(result2);
                Assert.True(result3);
                Assert.False(result4);
                Assert.False(result5);
                Assert.False(result6);
                Assert.False(result7);
                Assert.False(result8);
            }
        }
    }

}
}
