using System;
using System.Collections.Generic;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void gotoCustomersPage()
        {
            string usermode = lblMode.Content.ToString();
            CustomersPage cp = new CustomersPage();
            cp.lblMode.Content = usermode;
            cp.Title = "Welcome to Customers Page";
            cp.ShowDialog();
            
        }

        private void gotoFlightsPage()
        {
            string usermode = lblMode.Content.ToString();
            FlightsPage fp = new FlightsPage();
            fp.lblMode.Content = usermode;
            fp.Title = "Welcome to Flights Page";
            fp.ShowDialog();
            
        }

        private void gotoAirlinesPage()
        {
            string usermode = lblMode.Content.ToString();
            AirlinesPage ap = new AirlinesPage();
            ap.lblMode.Content = usermode;
            ap.Title = "Welcome to Airlines Page";
            ap.ShowDialog();
            
        }

        private void gotoPassengersPage()
        {
            string usermode = lblMode.Content.ToString();
            PassengersPage pp = new PassengersPage();
            pp.lblMode.Content = usermode;
            pp.Title = "Welcome to Passengers Page";
            pp.ShowDialog();
            
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            gotoCustomersPage();
        }

        private void btnFlights_Click(object sender, RoutedEventArgs e)
        {
            gotoFlightsPage();
        }

        private void btnAirlines_Click(object sender, RoutedEventArgs e)
        {
            gotoAirlinesPage();
        }

        private void btnPassengers_Click(object sender, RoutedEventArgs e)
        {
            gotoPassengersPage();
        }

        private void menuCustomers_Click(object sender, RoutedEventArgs e)
        {
            gotoCustomersPage();
        }

        private void menuFlights_Click(object sender, RoutedEventArgs e)
        {
            gotoFlightsPage();
        }

        private void menuAirlines_Click(object sender, RoutedEventArgs e)
        {
            gotoAirlinesPage();
        }

        private void menuPassengers_Click(object sender, RoutedEventArgs e)
        {
            gotoPassengersPage();
        }

        private void menuQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuInsert_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please choose one of the following pages to use this function", "Not Applicable (N/A)",
                                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please choose one of the following pages to use this function", "Not Applicable (N/A)",
                                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please choose one of the following pages to use this function", "Not Applicable (N/A)",
                                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void menuHelp_Click(object sender, RoutedEventArgs e)
        {
            
            HelpPage hp = new HelpPage();
            hp.Title = "Help Page";
            hp.ShowDialog();
            
        }
    }//ends class
}
