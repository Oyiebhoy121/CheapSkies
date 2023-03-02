using CheapSkies.Infrastructure.RepositoryInterface.ReservationRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;

namespace CheapSkies.Infrastructure.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private const string FilePath = "C:\\Users\\fgoleta\\Desktop\\CheapSkies\\CheapSkies\\CheapSkies.Infrastructure\\ReservationRepository\\ReservationRepository.txt";

        /// <summary>
        /// Saves an inputted validated Reservation properties to the ReservationRepository.txt file
        /// as a series of comma-separated strings. This will throw an Exception if the 
        /// File Path specified to ReservationtRepository.txt is non-existant
        /// </summary>
        /// <param name="reservation">Inputted Validated Reservation object by the user</param>
        public void SaveReservation(Reservation reservation)
        {
            string reservationProperties = string.Join(", ", reservation.AirlineCode, reservation.FlightNumber, reservation.ArrivalStation, reservation.DepartureStation, reservation.FlightDate, reservation.NumberOfPassenger,
                                                    reservation.PNR);
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(FilePath, append: true))
                {
                    streamWriter.WriteLine(reservationProperties);
                }
            }
            catch
            {
                Console.WriteLine("Failed to save the reservation data because File Path not found. Change it first.");
            }
        }

        /// <summary>
        /// Obtains all the the data from the ReservationRepository.txt  
        /// and then refactors the data as properties of ReservationBase Model. 
        /// This will throw an Exception if the 
        /// File Path specified to ReservationRepository.txt is non-existant
        /// </summary>
        /// <returns>List of All the Reservations in the ReservationRepository</returns>
        public List<ReservationBase> GetReservationData()
        {
            List<ReservationBase> listOfReservations = new List<ReservationBase>();

            try
            {
                using (StreamReader streamReader = new StreamReader(FilePath))
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

        /// <summary>
        /// Obtains all the data from the ReservationRepository.txt that matches with the Inputted PNR 
        /// and then refactors the data as properties of ReservationBase Model. 
        /// This will throw an Exception if the 
        /// File Path specified to ReservationRepository.txt is non-existant
        /// </summary>
        /// <param name="PNR">Inputted Passenger Name Record search key by the user</param>
        /// <returns>List of All the Reservations in the ReservationRepository that matches with the inputted PNR</returns>
        public List<ReservationBase> GetReservationData(string PNR) 
        {
            List<ReservationBase> listOfReservations = GetReservationData();

            return listOfReservations.Where(reservation => reservation.PNR == PNR).ToList();
        }

        /// <summary>
        /// Obtains all the PNR generated from the ReservationRepository.txt 
        /// This will throw an Exception if the 
        /// File Path specified to ReservationRepository.txt is non-existant
        /// </summary>
        /// <returns>List of All the PNR in the ReservationRepository</returns>
        public List<string> GetPNRData()
        {
            List<ReservationBase> listOfReservations = GetReservationData();

            return listOfReservations.Select(reservation => reservation.PNR).ToList();
        }

    }
}

