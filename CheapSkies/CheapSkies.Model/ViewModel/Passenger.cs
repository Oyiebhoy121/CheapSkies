using CheapSkies.Model.DataModel;

namespace CheapSkies.Model.ViewModel
{
    public class Passenger : PassengerBase
    {
        private DateOnly _birthDate;
        private readonly int _age;

        public string PNR { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateOnly BirthDate { get; }
        public int Age { get; }

        public Passenger() { }
        public Passenger(string pnr, string firstName, string lastName, DateOnly birthDate)
        {
            PNR = pnr;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            _age = CalculateAge(BirthDate);
            Age = _age;
        }
        private int CalculateAge(DateOnly birthDate)
        {
            TimeSpan difference = DateTime.Today - birthDate.ToDateTime(TimeOnly.Parse("00:00"));
            int age = (int)(difference.TotalDays / 365.25);
            return age;
        }
    }
}
