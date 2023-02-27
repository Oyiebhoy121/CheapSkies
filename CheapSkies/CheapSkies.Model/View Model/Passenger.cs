using CheapSkies.Model.DataModel;

namespace CheapSkies.Model.ViewModel
{
    public class Passenger : PassengerBase
    {
        private DateTime _birthDate;

        public string PNR { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public int Age => CalculateAge(_birthDate);
    
        public Passenger() { }
        public Passenger(string pnr, string firstName, string lastName, DateTime birthDate)
        {
            PNR = pnr;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
        private int CalculateAge(DateTime birthDate)
        {
            TimeSpan difference = DateTime.Today - birthDate;
            int age = (int)(difference.TotalDays / 365.25);
            return age;
        }
    }
}
