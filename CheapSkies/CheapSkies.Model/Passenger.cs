using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Model
{
    public class Passenger
    {
        private int _age;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get { return _age; }
            private set
            {
                TimeSpan difference = DateTime.Today - BirthDate;
                _age = (int)(difference.TotalDays / 365.25);
            }
        }



    }
}
