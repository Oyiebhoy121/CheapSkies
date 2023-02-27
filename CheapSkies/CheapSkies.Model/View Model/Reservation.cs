﻿using CheapSkies.Model.DataModel;

namespace CheapSkies.Model.ViewModel
{

    public class Reservation : ReservationBase
    {
        private List<string> _listOfPNR;

        public Reservation() { }
        public Reservation(string airlineCode, int flightNumber, string arrivalStation, string departureStation,
            DateTime flightDate, int numberOfPassenger, List<string> listOfPNR)
        {
            AirlineCode = airlineCode;
            FlightNumber = flightNumber;
            ArrivalStation = arrivalStation;
            DepartureStation = departureStation;
            FlightDate = flightDate;
            NumberOfPassenger = numberOfPassenger;
            _listOfPNR = listOfPNR;
        }

        public DateTime FlightDate { get; set; }
        public int NumberOfPassenger { get; set; }
        public string PNR => GeneratePNR();
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
