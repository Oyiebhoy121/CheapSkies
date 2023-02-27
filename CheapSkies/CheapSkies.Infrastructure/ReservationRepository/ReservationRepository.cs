using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Infrastructure
{
    public class ReservationRepository
    {
        private string _filePath =
            "C:\\Users\\frgol\\OneDrive\\Desktop\\CheapSkies\\CheapSkies\\CheapSkies.Infrastructure\\ReservationRepository\\ReservationRepository.txt";

        public void SaveReservation(Reservation reservation)
        {
            string reservationProperties = String.Join(", ", reservation.AirlineCode, reservation.FlightNumber,
                                                    reservation.ArrivalStation, reservation.DepartureStation,
                                                    reservation.FlightDate, reservation.NumberOfPassenger,
                                                    reservation.PNR);

            using (StreamWriter streamWriter = new StreamWriter(_filePath, append: true))
            {
                streamWriter.Write(reservationProperties);
            }
        }

        public List<ReservationBase> GetReservationData() //Get All Flight Data
        {
            List<ReservationBase> listOfReservations = new List<ReservationBase>();

            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                string textLines;
                while ((textLines = streamReader.ReadLine()) != null)
                {
                    string[] reservationProperties = textLines.Split(", ");
                    ReservationBase reservation = new ReservationBase()
                    {
                        AirlineCode = reservationProperties[0],
                        FlightNumber = Int32.Parse(reservationProperties[1]),
                        ArrivalStation = reservationProperties[2],
                        DepartureStation = reservationProperties[3],
                        FlightDate = DateTime.Parse(reservationProperties[4]),
                        NumberOfPassenger = Int32.Parse(reservationProperties[5]),
                        PNR = reservationProperties[6]
                    };
                    listOfReservations.Add(reservation);
                }
            }
            return listOfReservations;
        }

        public List<ReservationBase> GetReservationData(string PNR) //Get Reservation Data via PNR
        {
            List<ReservationBase> listOfReservations = GetReservationData();

            return listOfReservations.Where(reservation => reservation.PNR == PNR).ToList();
        }

        public List<string> GetPNR()
        {
            List<ReservationBase> listOfReservations = GetReservationData();

            return listOfReservations.Select(reservation => reservation.PNR).ToList();
        }
    }
}

