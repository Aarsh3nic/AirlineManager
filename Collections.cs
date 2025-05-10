using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Midterm_CS
{
    class Collections
    {
        Dictionary<string, Logins> userData = new Dictionary<string, Logins>();

        public void addUserData(string username, Logins userlogin)
        {
            userData.Add(username, userlogin);
        }

        public Dictionary<string, Logins> getUserData()
        {
            Dictionary<string, Logins> userInfo = new Dictionary<string, Logins>();

            foreach (var user in userData)
            {
                userInfo.Add(user.Key, user.Value);
            }

            return userInfo;
        }

        public void deleteUserData(string username)
        {
            userData.Remove(username);
        }

        //-------------------------Login Collection ends--------------------------



        List<Customer> customerData = new List<Customer>();



        public void addCustomerData(Customer customer)
        {
            customerData.Add(customer);
        }

        public List<Customer> getCustomerData()
        {
            List<Customer> customerInfo = new List<Customer>();

            foreach (var customer in customerData)
            {
                customerInfo.Add(customer);
            }

            return customerInfo;
        }

        public void deletecustomerData(int id)
        {
            int index = customerData.FindIndex(x => x.Id == id);
            customerData.RemoveAt(index);
        }

        public void updatecustomerData(int id, Customer customer)
        {
            customerData[id] = customer;
        }

        public void updateCustId(int oldId,int newID)
        {
            customerData[oldId].Id = newID;
        }

        public void getCustomerCollection()
        {
            addCustomerData(new Customer(101, "Aarsh Patel", "200 Malta Ave", "radioactive@gmail.com", "1234567890"));
            addCustomerData(new Customer(102, "Jeel Patel", "24 Malta Ave", "jeelpatel@gmail.com", "1234567890"));
            addCustomerData(new Customer(103, "Jay Patel", "26 Malta Ave", "jaypatel@gmail.com", "1234567890"));
            addCustomerData(new Customer(104, "Abhimanyu Patel", "29 Malta Ave", "abhipatel@gmail.com", "1234567890"));
            addCustomerData(new Customer(105, "Sushant Singh Rajput", "22 Malta Ave", "liveforever@gmail.com", "1234567890"));
        }
        //-------------------------Customer Collection ends--------------------------

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

        public void updateflightsData(int id, Flights flight)
        {
            flightsData[id] = flight;
        }
        public void updateflightId(int oldId, int newID)
        {
            flightsData[oldId].Id = newID;
        }

        public void getFlightsCollection()
        {
            addflightsData(new Flights(50,1001, "Ahemdabad", "Toronto", "2nd July 2019",13.5));
            addflightsData(new Flights(51, 1002, "Ahemdabad", "Montreal",  "2nd July 2019", 14.5));
            addflightsData(new Flights(52, 1003, "Ahemdabad", "Paris", "2nd July 2019",7.5));
            addflightsData(new Flights(53, 1004, "Ahemdabad", "London",  "2nd July 2019", 6.5));
            addflightsData(new Flights(54, 1005, "Ahemdabad", "Mumbai", "2nd July 2019", 12.5));
        }

        //-------------------------Flights Collection ends--------------------------

        Queue<Airlines> airlinesData = new Queue<Airlines>();

        public void addairlinesData(Airlines airlines)
        {
            airlinesData.Enqueue(airlines);
        }

        public void deleteLastairlinesData(out Airlines airlines)
        {
           airlines =  airlinesData.Dequeue();
        }

        public Queue<Airlines> getairlinesData()
        {
            //Queue<Airlines> airlinesInfo = new Queue<Airlines>();

            //foreach (var airline in airlinesData)
            //{
            //    airlinesInfo.Enqueue(airline);
            //}

            //return airlinesInfo;

            return airlinesData;
        }

        public void deleteairlinesData(int id )
        {
            this.airlinesData = new Queue<Airlines>(this.airlinesData.Where(x => x.Id != id));
        }

       
        
        public void updateairlinesData(int id, Airlines airline)
        {
            Queue<Airlines> air = new Queue<Airlines>();

            int temp = airlinesData.Count;
            for(int i=0; i<temp; i++)
            
            {
                var element = airlinesData.Dequeue();

                if(element.Id == id)
                {
                    air.Enqueue(airline);
                }
                else
                {
                    air.Enqueue(element);
                }
                
            }

            foreach (var e in air)
            {
                airlinesData.Enqueue(e);
            }

          

        }//ends updateAirData

        public void getAirlinesCollection()
        {
            addairlinesData(new Airlines(1001, "Emirates", "Boeing 777", 22, "Sushi"));
            addairlinesData(new Airlines(1002, "Ethihad", "Airbus 320", 28, "Salad"));
            addairlinesData(new Airlines(1003, "King Fisher", "Boeing 777", 28, "Sushi"));
            addairlinesData(new Airlines(1004, "Air India", "Airbus 320", 77, "Veg Thali"));
            addairlinesData(new Airlines(1005, "Air Canada", "Boeing 777", 82, "Salad"));
        }
        //-------------------------Airlines Collection ends--------------------------

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

        public void deletepassengerData(int id)
        {
            passengerData= new Stack<Passenger>(passengerData.Where(x => x.Id != id));
        }

        public void deleteLastpassengerData(out Passenger passenger)
        {
            passenger = passengerData.Pop();
        }

        public void deletingpassenger()
        {
            int count = getpassengerData().Count;
            Stack<Passenger> passengerInfo = new Stack<Passenger>();
            Passenger passenger = new Passenger();
            for (int i = count - 1; i >= 0; i--)
            {
                deleteLastpassengerData(out passenger);
                passenger.Id = i + 500;

                passengerInfo.Push(passenger);

                //collection.updateCustId(i, i + 101);
            }

            foreach ( var p in passengerInfo)
            {
                passengerData.Push(p);
            }
        }
        public void updatepassengerData(int id, Passenger passenger)
        {
            
            Stack<Passenger> passstack = new Stack<Passenger>();
            int count = passengerData.Count;
            for(int i = count-1; i>=0; i--)
            {
                var element = passengerData.Pop();

                if (element.Id == id)
                {
                    passenger.Id = i + 500;
                    passstack.Push(passenger);
                    
                }
                else
                {
                    passstack.Push(element);
                }
            }

            foreach (var e in passstack)
            {
                passengerData.Push(e);
            }

            }//ends updatePassenger
        

        public void getPassengerCollection()
        {
            addpassengerData(new Passenger(500,101,50));
            addpassengerData(new Passenger(501, 102, 51));
            addpassengerData(new Passenger(502, 103, 52));
            addpassengerData(new Passenger(503, 104, 53));
            addpassengerData(new Passenger(504, 105, 54));
        }
        

        //-------------------------Passengers Collection ends--------------------------

    }//class ends
}
