using CheapSkies.Controller.Validators;
using CheapSkies.Model.ViewModel;
using Xunit;


namespace PassengerValidatorUnitTest
{
    public class PNRUnitTests
    {
        [Fact]
        public void GeneratePNR_WhenPNRIsGenerated_ReturnsAllCapitalLetters()
        {
            //Arrange
            Reservation reservation = new Reservation("5J", 124, "MNL", "CEB", new DateOnly(2023, 7, 8), 1, new List<string>());
            string pnr = reservation.PNR;

            //Act

            //Assert
            Assert.Equal(pnr.ToUpper(), pnr);
        }

        [Fact]
        public void GeneratePNR_WhenPNRIsGenerated_ReturnsSixAlphaNumericCharacters()
        {
            //Arrange
            Reservation reservation = new Reservation("5J", 124, "MNL", "CEB", new DateOnly(2023, 7, 8), 1, new List<string>());
            int pnrLength = reservation.PNR.Length;
            string pnr = reservation.PNR;
            //Act
            bool isAlphaNumeric = pnr.All(c => Char.IsLetterOrDigit(c));

            //Assert
            Assert.Equal(6, pnrLength);
            Assert.True(isAlphaNumeric);
        }

        [Fact]
        public void GeneratePNR_WhenPNRIsGenerated_ReturnsFirstCharacterAsLetter()
        {
            //Arrange
            Reservation reservation = new Reservation("5J", 124, "MNL", "CEB", new DateOnly(2023, 7, 8), 1, new List<string>());
            char firstCharacter = reservation.PNR[0];
            //Act;

            //Assert
            Assert.True(Char.IsLetter(firstCharacter));
        }
    }
}