using CheapSkies.Infrastructure.RepositoryInterface.PassengerRepository.Interface;
using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;

namespace CheapSkies.Infrastructure.Repositories.PassengerRepository
{
    public class PassengerRepository : IPassengerRepository
    {
        private const string FilePath = "C:\\Users\\fgoleta\\Desktop\\CheapSkies\\CheapSkies\\CheapSkies.Infrastructure\\Repository\\ReservationRepository\\ReservationRepository.txt";

        /// <summary>
        /// Saves an inputted validated Passenger properties to the PassengerRepository.txt file
        /// as a series of comma-separated strings. This will throw an Exception if the 
        /// File Path specified to PassengerRepository.txt is non-existant
        /// </summary>
        /// <param name="passenger">Inputted Validated Passenger object by the user</param>
        public void SavePassenger(Passenger passenger)
        {
            string passengerProperties = string.Join(", ", passenger.PNR, passenger.FirstName, passenger.LastName, passenger.BirthDate, passenger.Age);

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(FilePath, append: true))
                {
                    streamWriter.WriteLine(passengerProperties);
                }
            }
            catch
            {
                Console.WriteLine("Failed to save the passengers because Saving File Path is not found. Change it first.");
            }
        }

        /// <summary>
        /// Saves a list inputted validated Passenger properties to the PassengerRepository.txt file
        /// as a series of comma-separated strings. This will throw an Exception if the 
        /// File Path specified to PassengerRepository.txt is non-existant
        /// </summary>
        /// <param name="listOfPassengers">List of Inputted Validated Passenger objects by the user</param>
        public void SavePassenger(List<Passenger> listOfPassengers)
        {
            string passengerProperties = "";
            foreach (Passenger passenger in listOfPassengers)
            {
                passengerProperties = string.Join(", ", passenger.PNR, passenger.FirstName, passenger.LastName, passenger.BirthDate, passenger.Age);

                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(FilePath, append: true))
                    {
                        streamWriter.WriteLine(passengerProperties);
                    }
                }
                catch
                {
                    Console.WriteLine("Failed to save the passengers because Saving File Path is not found. Change it first.");
                }
            }
        }

        /// <summary>
        /// Obtains all the the data from the PassengerRepository.txt that matches with the inputted PNR 
        /// and then refactors the data as properties of PassengerBase Model. 
        /// This will throw an Exception if the 
        /// File Path specified to PassengerRepository.txt is non-existant
        /// </summary>
        /// <param name="PNR">Inputted Passenger Name Record search key by the user</param>
        /// <returns>List of All the Passengers in the Passenger Repository that matches with the given PNR</returns>
        public List<PassengerBase> GetPassengerData(string PNR)
        {
            List<PassengerBase> listOfPassengers = GetPassengerData();

            return listOfPassengers.Where(passenger => passenger.PNR == PNR).ToList();
        }

        /// <summary>
        /// Obtains all the the data from the PassengerRepository.txt
        /// and then refactors the data as properties of PassengerBase Model. 
        /// This will throw an Exception if the 
        /// File Path specified to PassengerRepository.txt is non-existant
        /// </summary>
        /// <returns>List of All the Passengers in the Passenger Repository</returns>
        private List<PassengerBase> GetPassengerData()
        {
            List<PassengerBase> listOfPassengers = new List<PassengerBase>();

            try
            {
                using (StreamReader streamReader = new StreamReader(FilePath))
                {
                    string textLines;
                    while ((textLines = streamReader.ReadLine()) != null)
                    {
                        string[] passengerProperties = textLines.Split(", ");
                        PassengerBase passenger = new PassengerBase()
                        {
                            PNR = passengerProperties[0],
                            FirstName = passengerProperties[1],
                            LastName = passengerProperties[2],
                            BirthDate = DateOnly.Parse(passengerProperties[3]),
                            Age = int.Parse(passengerProperties[4])
                        };
                        listOfPassengers.Add(passenger);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Failed to read the passenger data because Saving File Path is not found. Change it first.");
            }

            return listOfPassengers;
        }

    }
}