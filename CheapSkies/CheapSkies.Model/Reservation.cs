using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Model
{
    
    public class Reservation : Record
    {
        private List<string> _listOfPNR;

        public Reservation() : base() { }
        public Reservation(string airlineCode, int flightNumber, string arrivalStation, string departureStation,
            DateTime flightDate, int numberOfPassenger, List<string> listOfPNR)
            : base(airlineCode, flightNumber, arrivalStation, departureStation)
        {
            FlightDate = flightDate;
            NumberOfPassenger = numberOfPassenger;
            _listOfPNR = listOfPNR;
        }

        public DateTime FlightDate { get; set; }
        public int NumberOfPassenger { get; set; }
        public string PNR
        {
            get { return GeneratePNR(); }

        }
        //Unit Test still needed for this.
        private string GeneratePNR()
        {
            Random random = new Random();
            int probability;
            string pnr = "";

            do
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0)
                    {
                        pnr = "";
                        pnr += Convert.ToChar(random.Next(65, 91));
                    }
                    else
                    {
                        probability = random.Next(1, 3);
                        if (probability == 1)
                        {
                            pnr += random.Next(0, 9);
                        }
                        else
                        {
                            pnr += Convert.ToChar(random.Next(65, 91));
                        }
                    }
                }
            } while (_listOfPNR.Contains(pnr));
            return pnr;
        }
    }
}
