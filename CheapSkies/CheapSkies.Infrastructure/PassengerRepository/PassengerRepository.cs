using CheapSkies.Model.DataModel;
using CheapSkies.Model.ViewModel;
using Interfaces;
using System;
using System.IO;
using System.Linq;

namespace CheapSkies.Infrastructure
{
    public class PassengerRepository
    {
        private string _filePath = "C:\\Users\\fgoleta\\Desktop\\CheapSkies\\CheapSkies\\CheapSkies.Infrastructure\\PassengerRepository\\PassengerRepository.txt";

        public void SavePassenger(Passenger passenger)
        {
            string passengerProperties = String.Join(", ", passenger.PNR, passenger.FirstName, passenger.LastName, passenger.BirthDate, passenger.Age);

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(_filePath, append: true))
                {
                    streamWriter.WriteLine(passengerProperties);
                }
            }
            catch
            {
                Console.WriteLine("Failed to save the passengers because Saving File Path is not found. Change it first.");
            }
        }

        public void SavePassenger(List<Passenger> listOfPassengers)
        {
            string passengerProperties = "";
            foreach(Passenger passenger in listOfPassengers)
            {
                passengerProperties = String.Join(", ", passenger.PNR, passenger.FirstName, passenger.LastName, passenger.BirthDate, passenger.Age);

                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(_filePath, append: true))
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

        public List<PassengerBase> GetPassengerData(string PNR) //Get Passenger Data via PNR
        {
            List<PassengerBase> listOfPassengers = GetPassengerData();

            return listOfPassengers.Where(passenger => passenger.PNR == PNR).ToList();
        }

        private List<PassengerBase> GetPassengerData() //Get All Passenger Data
        {
            List<PassengerBase> listOfPassengers = new List<PassengerBase>();

            try
            {
                using (StreamReader streamReader = new StreamReader(_filePath))             
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
                            Age = Int32.Parse(passengerProperties[4])
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