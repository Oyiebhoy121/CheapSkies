using CheapSkies.Controller.Validators;
using CheapSkies.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapSkies.Controller.Controller
{
    public class RecordController
    {
        private GeneralRecordScreen _generalRecordScreen;
        private RecordValidator _recordValidator;

        public RecordController() { }
        public RecordController(GeneralRecordScreen generalRecordScreen, RecordValidator recordValidator)
        {
            _generalRecordScreen = generalRecordScreen;
            _recordValidator = recordValidator;
        }
        public string GetAirlineCode()
        {
            string airlineCode;
            bool parse;

            do
            {
                airlineCode = _generalRecordScreen.AskForAirlineCodeAndGetInput();
                parse = _recordValidator.ValidateAirlineCode(airlineCode);
                if (parse == false)
                {
                    _generalRecordScreen.DisplayInvalidAirlineCodeMessage();
                }
            } while (!parse);

            return airlineCode;
        }

        public int GetFlightNumber()
        {
            string flightNumber;
            bool parse;

            do
            {
                flightNumber = _generalRecordScreen.AskForFlightNumberAndGetInput();
                parse = _recordValidator.ValidateFlightNumber(flightNumber);
                if (parse == false)
                {
                    _generalRecordScreen.DisplayInvalidFlightNumberMessage();
                }
            } while (!parse);

            return Int32.Parse(flightNumber);
        }

        public string GetStation(string arrivalOrDepartureStation)
        {
            string station;
            bool parse;

            do
            {
                station = _generalRecordScreen.AskForStationAndGetInput(arrivalOrDepartureStation);
                parse = _recordValidator.ValidateStation(station);
            } while (!parse);
            return station;
        }
    }
}

