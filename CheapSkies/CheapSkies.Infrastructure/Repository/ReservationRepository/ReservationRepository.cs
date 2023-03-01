using CheapSkies.Infrastructure.RepositoryInterface.ReservationRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;

namespace CheapSkies.Infrastructure.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private string _filePath = "C:\\Users\\fgoleta\\Desktop\\CheapSkies\\CheapSkies\\CheapSkies.Infrastructure\\ReservationRepository\\ReservationRepository.txt";

        public void SaveReservation(Reservation reservation)
        {
            string reservationProperties = string.Join(", ", reservation.AirlineCode, reservation.FlightNumber, reservation.ArrivalStation, reservation.DepartureStation, reservation.FlightDate, reservation.NumberOfPassenger,
                                                    reservation.PNR);
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(_filePath, append: true))
                {
                    streamWriter.WriteLine(reservationProperties);
                }
            }
            catch
            {
                Console.WriteLine("Failed to save the reservation data because File Path not found. Change it first.");
            }
        }
        public List<ReservationBase> GetReservationData() //Get All Flight Data
        {
            List<ReservationBase> listOfReservations = new List<ReservationBase>();

            try
            {
                using (StreamReader streamReader = new StreamReader(_filePath))
                {
                    string textLines;
                    while ((textLines = streamReader.ReadLine()) != null)
                    {
                        string[] reservationProperties = textLines.Split(", ");
                        ReservationBase reservation = new ReservationBase()
                        {
                            AirlineCode = reservationProperties[0],
                            FlightNumber = int.Parse(reservationProperties[1]),
                            ArrivalStation = reservationProperties[2],
                            DepartureStation = reservationProperties[3],
                            FlightDate = DateOnly.Parse(reservationProperties[4]),
                            NumberOfPassenger = int.Parse(reservationProperties[5]),
                            PNR = reservationProperties[6]
                        };
                        listOfReservations.Add(reservation);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Failed to save the reservation data because File Path not found. Change it first.");
            }
            return listOfReservations;
        }
        public List<ReservationBase> GetReservationData(string PNR) //Get Reservation Data via PNR
        {
            List<ReservationBase> listOfReservations = GetReservationData();

            return listOfReservations.Where(reservation => reservation.PNR == PNR).ToList();
        }
        public List<string> GetPNRData()
        {
            List<ReservationBase> listOfReservations = GetReservationData();

            return listOfReservations.Select(reservation => reservation.PNR).ToList();
        }
    }
}

