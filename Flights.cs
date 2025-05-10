using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_CS
{
    class Flights
    {

        private int id;
        private int airlineId;
        private string departureCity;
        private string destinationCity;
        private string date;
        private double flightTime;

        public Flights(int id, int airlineId, string departureCity, string destinationCity, string date, double flightTime)
        {
            Id = id;
            AirlineId = airlineId;
            DepartureCity = departureCity;
            DestinationCity = destinationCity;
            Date = date;
            FlightTime = flightTime;
        }

        public int Id { get => id; set => id = value; }
        public int AirlineId { get => airlineId; set => airlineId = value; }
        public string DepartureCity { get => departureCity; set => departureCity = value; }
        public string DestinationCity { get => destinationCity; set => destinationCity = value; }
        public string Date { get => date; set => date = value; }
        public double FlightTime { get => flightTime; set => flightTime = value; }

        List<Flights> flightsData = new List<Flights>();



        public void addflightsData(Flights flights)
        {
            flightsData.Add(flights);
        }

        public List<Flights> getflightsData()
        {
            List<Flights> flightsInfo = new List<Flights>();

            foreach (var flight in flightsData)
            {
                flightsInfo.Add(flight);
            }

            return flightsInfo;
        }

        public void deleteflightsData(int id)
        {
            int index = flightsData.FindIndex(x => x.Id == id);
            flightsData.RemoveAt(index);
        }
    }//ends class
}
