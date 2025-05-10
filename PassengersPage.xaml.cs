using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Midterm_CS
{
    /// <summary>
    /// Interaction logic for PassengersPage.xaml
    /// </summary>
    public partial class PassengersPage : Window
    {
        Collections collection = new Collections();
        private bool readOnly = false;
        public PassengersPage()
        {
            InitializeComponent();

            collection.getPassengerCollection();

            collection.getCustomerCollection();

            collection.getFlightsCollection();


            var displayId = from user in collection.getpassengerData()
                            select "Passenger ID: " + user.Id ;

            listPassengers.DataContext = displayId;

        }

        //-----------------------------Button Starts----------------------------------
        private void listPassengers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = listPassengers.SelectedIndex + 500;

            var selectedPassengers = from p in collection.getpassengerData()
                                     where p.Id == index
                                     select p;

            foreach(var pass in selectedPassengers)
            {
                txtId.Text = pass.Id.ToString();
                txtCustId.Text = pass.CustomerId.ToString();
                txtFlight.Text = pass.FlightId.ToString();

                var selectedCustomers = from c in collection.getCustomerData()
                                        where c.Id == pass.CustomerId
                                        select "Customer ID: " +c.Id + " Customer Name: " + c.Name;

                listCustomers.DataContext = selectedCustomers;

                var selectedFlights = from f in collection.getflightsData()
                                      where f.Id == pass.FlightId
                                      select "Flight ID: "+f.Id + " Destination City " + f.DestinationCity;

                listFlights.DataContext = selectedFlights;
            }//for each ends



        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            addPassenger();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updatePassenger();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deletePassenger();
        }
        private void menuQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuInsert_Click(object sender, RoutedEventArgs e)
        {
            addPassenger();
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e)
        {
            updatePassenger();
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            deletePassenger();
        }

        private void menuHelp_Click(object sender, RoutedEventArgs e)
        {

            HelpPage hp = new HelpPage();
            hp.Title = "Help Page";
            hp.ShowDialog();

        }


        private void  addPassenger()
        {
            readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);

            MessageBoxResult res = MessageBoxResult.Yes;
            if (readOnly == true)
            {
                MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

            if (validateInput() && readOnly == false)
            {

                var duplicate = from p in collection.getpassengerData()
                                where (txtId.Text == p.Id.ToString() && txtCustId.Text == p.CustomerId.ToString() && txtFlight.Text == p.FlightId.ToString())
                                select p;
                if (duplicate.Any())
                {
                    res = MessageBox.Show("There's a entry of Same Information You Still want to proceed ?", "Same Entry Found",
                            MessageBoxButton.YesNo, MessageBoxImage.Warning);


                }

                var existcust = from e in collection.getCustomerData()
                                where e.Id == int.Parse(txtCustId.Text)
                                select e;

                if (!(existcust.Any()))
                {
                    MessageBox.Show("Please enter Customer ID which is listed", "Invalid Entry",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }

                var existflight = from e in collection.getflightsData()
                                  where e.Id == int.Parse(txtFlight.Text)
                                  select e;

                if (!(existflight.Any()))
                {
                    MessageBox.Show("Please enter Flight ID which is listed", "Invalid Entry",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }


                if (res == MessageBoxResult.Yes && existcust.Any() == true && existflight.Any() == true)
                {

                    collection.addpassengerData(new Passenger(collection.getpassengerData().Count+ 500, int.Parse(txtCustId.Text),int.Parse(txtFlight.Text)));

                    var displayId = from user in collection.getpassengerData()
                                    select "Passenger ID: " + user.Id;

                    listPassengers.DataContext = displayId;


                    MessageBox.Show("Passenger Added", "Done!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    txtId.Text = "";
                    txtCustId.Text = "";
                    txtFlight.Text = "";

                }
                else
                {
                    MessageBox.Show("Passenger Not Added", "Done!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    txtId.Text = "";
                    txtCustId.Text = "";
                    txtFlight.Text = "";
                   
                }


            }
            }//ends addPassenger

        private void updatePassenger()
        {

            readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);

            if (readOnly == true)
            {
                MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }

            bool valid = (listPassengers.SelectedIndex != -1 ? true : false);

            if (valid == false)
            {
                MessageBox.Show("Please Select Item to UPDATE", "Invalid Attempt",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                if (validateInput() && readOnly == false)
                {
                    var duplicate = from p in collection.getpassengerData()
                                    where (txtId.Text == p.Id.ToString() && txtCustId.Text == p.CustomerId.ToString() && txtFlight.Text == p.FlightId.ToString())
                                    select p;
                    if (duplicate.Any())
                    {
                        MessageBox.Show("There's a entry of Same Information Please Enter the Differences", "Same Entry Found",
                               MessageBoxButton.OK, MessageBoxImage.Error);


                    }
                    else
                    {
                        var existcust = from e in collection.getCustomerData()
                                        where e.Id == int.Parse(txtCustId.Text)
                                        select e;

                        if (!(existcust.Any()))
                        {
                            MessageBox.Show("Please enter Customer ID which is listed", "Invalid Entry",
                                   MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                        var existflight = from e in collection.getflightsData()
                                          where e.Id == int.Parse(txtFlight.Text)
                                          select e;

                        if (!(existflight.Any()))
                        {
                            MessageBox.Show("Please enter Flight ID which is listed", "Invalid Entry",
                                   MessageBoxButton.OK, MessageBoxImage.Error);
                        }


                        if (existcust.Any() == true && existflight.Any() == true)
                        {
                            Passenger passenger = new Passenger(listPassengers.SelectedIndex + 500 , int.Parse(txtCustId.Text),
                                int.Parse(txtFlight.Text));

                            collection.updatepassengerData(listPassengers.SelectedIndex, passenger);

                            var displayId = from user in collection.getpassengerData()
                                            select "Passenger ID: " + user.Id;

                            listPassengers.DataContext = displayId;

                            MessageBox.Show("Passenger Updated", "Done!!!",
                                       MessageBoxButton.OK, MessageBoxImage.Information);

                            txtId.Text = "";
                            txtCustId.Text = "";
                            txtFlight.Text = "";


                        }
                    }
                }
            }



        }//ends updatePassenger

        private void deletePassenger()
        {

            readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);
            if (readOnly == true)
            {
                MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }

            bool valid = (listPassengers.SelectedIndex != -1 ? true : false);

            if (valid == false)
            {
                MessageBox.Show("Please Select Item to DELETE", "Invalid Attempt",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (readOnly == false)
            {
                collection.deletepassengerData(listPassengers.SelectedIndex+500);

                collection.deletingpassenger();
               // deletePassenger();

                var displayId = from user in collection.getpassengerData()
                                orderby user.Id 
                                select "Passenger ID: " + user.Id
                                ;

                listPassengers.DataContext = displayId;

                MessageBox.Show("Passenger Deleted", "Done!!!",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                txtId.Text = "";
                txtCustId.Text = "";
                txtFlight.Text = "";
            }


            }//ends deletePassenger

        private bool validateInput()
        {

            bool valid = true;
            if (txtId.Text == "" || txtCustId.Text == "" ||
               txtFlight.Text == "" )
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }

            else
            {


                try
                {
                    int temp = int.Parse(txtId.Text);

                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Please Enter NUMBER as  Id", "Invalid Entry",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    valid = false;
                }


                try
                {
                    int temp = int.Parse(txtCustId.Text);

                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Please Enter NUMBER as  Customer Id", "Invalid Entry",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    valid = false;
                }

                try
                {
                    int temp = int.Parse(txtFlight.Text);

                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Please Enter NUMBER as  Flight ID", "Invalid Entry",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    valid = false;
                }
            }

            //try
            //{
            //    long temp = long.Parse(txtPhone.Text);
            //    if (!(temp >999999999 && temp<= 9999999999))
            //    {
            //        MessageBox.Show("Please Enter 10 Digits as a Phone NUMBER ", "Invalid Entry",
            //            MessageBoxButton.OK, MessageBoxImage.Error);
            //        valid = false;
            //    }

            //}
            //catch (System.FormatException)
            //{
            //    MessageBox.Show("Please Enter NUMBER as  Phone", "Invalid Entry",
            //            MessageBoxButton.OK, MessageBoxImage.Error);
            //    valid = false;
            //}
            //}

            return valid;
        }//ends validateInput Method
    }//ends class
}

