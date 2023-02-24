using CheapSkies.Validator;

namespace PassengerValidatorUnitTest
{
    public class ValidateNameUnitTest
    {
        [Fact]
        public void ValidateNameUnitTest1()
        {
            //Arrange
            var sut = new PassengerValidator();
            string name1 = "";
            string name2 = "Felipe";
            string name3 = "Ang Pangalan ko ay Sobra Sobra";
            //Act
            bool result1 = sut.ValidateName(name1);
            bool result2 = sut.ValidateName(name2);
            bool result3 = sut.ValidateName(name3);
            //Assert
            Assert.False(result1);
            Assert.True(result2);
            Assert.False(result3);
        }
    }
}