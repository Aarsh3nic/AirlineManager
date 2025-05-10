using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm_CS
{
    class Passenger
    {
        private int id;
        private int customerId;
        private int flightId;

        public Passenger(int id, int customerId, int flightId)
        {
            Id = id;
            CustomerId = customerId;
            FlightId = flightId;
        }

        public Passenger()
        {
        }

        public int Id { get => id; set => id = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public int FlightId { get => flightId; set => flightId = value; }

        Stack<Passenger> passengerData = new Stack<Passenger>();
        public void addpassengerData(Passenger passenger)
        {
            passengerData.Push(passenger);
        }

        public Stack<Passenger> getpassengerData()
        {
            Stack<Passenger> passengerInfo = new Stack<Passenger>();

            foreach (var passenger in passengerData)
            {
                passengerInfo.Push(passenger);
            }

            return passengerInfo;
        }

        public void deletepassengerData(int id, out Stack<Passenger> passengerInfo)
        {
            passengerInfo = new Stack<Passenger>(passengerData.Where(x => x.Id != id));
        }
    }//class ends
}
