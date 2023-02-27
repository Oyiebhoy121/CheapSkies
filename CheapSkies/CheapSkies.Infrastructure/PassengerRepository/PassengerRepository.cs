using CheapSkies.Interfaces;
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
        private string _filePath =
            "C:\\Users\\frgol\\OneDrive\\Desktop\\CheapSkies\\CheapSkies\\CheapSkies.Infrastructure\\PassengerRepository\\PassengerRepository.txt";

        public void SavePassenger(Passenger passenger)
        {
            string passengerProperties = String.Join(", ", passenger.PNR, passenger.FirstName, passenger.LastName,
                                                    passenger.BirthDate, passenger.Age);

            using (StreamWriter streamWriter = new StreamWriter(_filePath, append: true))
            {
                streamWriter.Write(passengerProperties);
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
                        BirthDate = DateTime.Parse(passengerProperties[3]),
                        Age = Int32.Parse(passengerProperties[4])
                    };
                    listOfPassengers.Add(passenger);
                }
            }
            return listOfPassengers;
        }
        
    }
}