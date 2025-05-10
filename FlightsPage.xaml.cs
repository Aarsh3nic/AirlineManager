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
    /// Interaction logic for FlightsPage.xaml
    /// </summary>
    public partial class FlightsPage : Window
    {
        Collections collection = new Collections();
        private bool readOnly = false;
        public FlightsPage()
        {
            InitializeComponent();


            collection.getFlightsCollection();
            collection.getAirlinesCollection();

            var dtcity = from user in collection.getflightsData()
                        select user.DestinationCity;
            listFlights.DataContext = dtcity;

            

        }//ends constructor

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listFlights.SelectedIndex + 50;
           


            var selectedFlights = from user in collection.getflightsData()
                                    where user.Id == index
                                    select user;

            

            //var fid = from f in collection.getairlinesData()
            //          where f.Id == findex
            //          select f.Name + " ID: " + f.Id;

            foreach (var sc in selectedFlights)
            {
                txtId.Text = sc.Id.ToString();
                txtAirlineId.Text = sc.AirlineId.ToString();
                txtDPcity.Text = sc.DepartureCity;
                txtDTcity.Text = sc.DestinationCity;
                txtDdate.Text = sc.Date;
                txtFlightTime.Text = sc.FlightTime.ToString();

                var fids = from f in collection.getairlinesData()
                           where f.Id == sc.AirlineId
                           select f.Name + " ID: " + f.Id;
                listAirlineId.DataContext = fids;
            }

            


        }

        private void menuQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuInsert_Click(object sender, RoutedEventArgs e)
        {
            addFlight();
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateFlight();
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteFlight();
        }

        private void menuHelp_Click(object sender, RoutedEventArgs e)
        {

            HelpPage hp = new HelpPage();
            hp.Title = "Help Page";
            hp.ShowDialog();

        }

        //-----------------------------Button Starts----------------------------------

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            addFlight();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateFlight();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteFlight();
        }

        //-----------------------------Button ends----------------------------------


        private void addFlight()
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

                var duplicate = from u in collection.getflightsData()
                                where (txtAirlineId.Text == u.AirlineId.ToString() && txtDPcity.Text == u.DepartureCity && txtDTcity.Text == u.DestinationCity && txtDdate.Text == u.Date && txtFlightTime.Text == u.FlightTime.ToString())
                                select u;
                if (duplicate.Any())
                {
                    res = MessageBox.Show("There's a entry of Same Information You Still want to proceed ?", "Same Entry Found",
                            MessageBoxButton.YesNo, MessageBoxImage.Warning);


                }

                var exist = from e in collection.getairlinesData()
                            where e.Id == int.Parse(txtAirlineId.Text)
                            select e;

                if (!(exist.Any()))
                {
                    MessageBox.Show("Please enter Airline ID which is listed", "Invalid Entry",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (res == MessageBoxResult.Yes && exist.Any()==true)
                {
                    collection.addflightsData(new Flights(collection.getflightsData().Count + 50, int.Parse(txtAirlineId.Text),
                                    txtDPcity.Text, txtDTcity.Text,
                                    txtDdate.Text,double.Parse(txtFlightTime.Text)));

                    var dtcity = from user in collection.getflightsData()
                                 select user.DestinationCity;
                    listFlights.DataContext = dtcity;
                    MessageBox.Show("Flight Added", "Done!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Flight Not Added", "Done!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    txtId.Text = "";
                    txtAirlineId.Text = "";
                    txtDPcity.Text = "";
                    txtDTcity.Text = "";
                    txtDdate.Text = "";
                    txtFlightTime.Text = "";
                }

            }
        }//ends addflight

        private void updateFlight()
        {
            readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);

            if (readOnly == true)
            {
                MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }

            bool valid = (listFlights.SelectedIndex != -1 ? true : false);

            if (valid == false)
            {
                MessageBox.Show("Please Select Item to UPDATE", "Invalid Attempt",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (validateInput() && readOnly == false)
                {
                    var duplicate = from u in collection.getflightsData()
                                    where (txtAirlineId.Text == u.AirlineId.ToString() && txtDPcity.Text == u.DepartureCity && txtDTcity.Text == u.DestinationCity && txtDdate.Text == u.Date && txtFlightTime.Text == u.FlightTime.ToString())
                                    select u;
                    if (duplicate.Any())
                    {
                        MessageBox.Show("There's a entry of Same Information Please Enter the Differences", "Same Entry Found",
                               MessageBoxButton.OK, MessageBoxImage.Error);


                    }

                    else
                    {

                        var exist = from e in collection.getairlinesData()
                                    where e.Id == int.Parse(txtAirlineId.Text)
                                    select e;

                        if (!(exist.Any()))
                        {
                            MessageBox.Show("Please enter Airline ID which is listed", "Invalid Entry",
                                   MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else { 
                        Flights flight = new Flights(listFlights.SelectedIndex + 50, int.Parse(txtAirlineId.Text),
                                             txtDPcity.Text, txtDTcity.Text,
                                             txtDdate.Text, double.Parse(txtFlightTime.Text));

                                collection.updateflightsData(listFlights.SelectedIndex, flight);



                                var dtcity = from user in collection.getflightsData()
                                             select user.DestinationCity;
                                listFlights.DataContext = dtcity;


                                MessageBox.Show("Flight Updated", "Done!!!",
                                        MessageBoxButton.OK, MessageBoxImage.Information);

                                txtId.Text = "";
                                txtAirlineId.Text = "";
                                txtDPcity.Text = "";
                                txtDTcity.Text = "";
                                txtDdate.Text = "";
                                txtFlightTime.Text = "";
                        }

                    }
                }
            }
            }//ends updateFlight

        private void deleteFlight()
            {
                readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);
                if (readOnly == true)
                {
                    MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                }

                bool valid = (listFlights.SelectedIndex != -1 ? true : false);

                if (valid == false)
                {
                    MessageBox.Show("Please Select Item to DELETE", "Invalid Attempt",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (readOnly == false)
                {

                    collection.deleteflightsData(listFlights.SelectedIndex + 50);


                    for (int i = 0; i < collection.getflightsData().Count; i++)
                    {
                        collection.updateflightId(i, i + 50);

                    }
                    var dtcity = from user in collection.getflightsData()
                                 select user.DestinationCity;
                    listFlights.DataContext = dtcity;


                    MessageBox.Show("Flight Deleted", "Done!!!",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                    txtId.Text = "";
                    txtAirlineId.Text = "";
                    txtDPcity.Text = "";
                    txtDTcity.Text = "";
                    txtDdate.Text = "";
                    txtFlightTime.Text = "";
                }
            
      }//ends deleteFlight

        private bool validateInput()
        {
             
            bool valid = true;
            if (txtId.Text == "" || txtAirlineId.Text == "" ||
               txtDPcity.Text == "" || txtDTcity.Text == "" || txtDdate.Text == "" || txtFlightTime.Text == "")
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
                    int temp = int.Parse(txtAirlineId.Text);

                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Please Enter NUMBER as  Airline Id", "Invalid Entry",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    valid = false;
                }

                try
                {
                    double temp = double.Parse(txtFlightTime.Text);

                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Please Enter NUMBER as  Flight Time", "Invalid Entry",
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

        
    }//ends classs 
}
