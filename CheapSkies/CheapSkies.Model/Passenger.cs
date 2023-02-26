using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Model
{
    public class Passenger
    {
        private DateTime _birthDate;
        private int _age;

        public Passenger() { }
        public Passenger(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set 
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentException("Birth date cannot be in the future");
                } 
                _birthDate = value;
            }
        }
        public int Age
        {
            get { return CalculateAge(_birthDate); }
            set { _age = value; }
        }
        private int CalculateAge(DateTime birthDate)
        {
            TimeSpan difference = DateTime.Today - birthDate;
            int age = (int)(difference.TotalDays / 365.25);
            return age;
        }
    }
}
