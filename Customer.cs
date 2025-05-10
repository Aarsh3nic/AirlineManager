using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_CS
{
    class Customer
    {

        private int id;
        private string name;
        private string address;
        private string email;
        private string phone;

        public Customer(int id, string name, string address, string email, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }

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
    }
}
