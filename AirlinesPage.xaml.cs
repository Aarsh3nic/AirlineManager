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
    /// Interaction logic for AirlinesPage.xaml
    /// </summary>
    public partial class AirlinesPage : Window
    {

        Collections collection = new Collections();
        private bool readOnly = false;
        public AirlinesPage()
        {
            InitializeComponent();

            collection.getAirlinesCollection();

            var names = from user in collection.getairlinesData()
                        select user.Name;
            listAirlines.DataContext = names;

        }//constructor ends

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listAirlines.SelectedIndex + 1001;


            var selectedAirlines = from user in collection.getairlinesData()
                                    where user.Id == index
                                    select user;

            foreach (var sc in selectedAirlines)
            {
                txtId.Text = sc.Id.ToString();
                txtName.Text = sc.Name;
                txtAirplane.Text = sc.Airplane;
                txtSeats.Text = sc.Seatsavailable.ToString();
                txtMeal.Text = sc.MealAvailable;
            }

            if(txtAirplane.Text == "Boeing 777")
            {
                radioB.IsChecked = true;
            }
            if (txtAirplane.Text == "Airbus 320")
            {
                radioA.IsChecked = true;
            }

            if (txtMeal.Text == "Sushi")
            {
                radioSushi.IsChecked = true;
            }

            if (txtMeal.Text == "Salad")
            {
                radioSalad.IsChecked = true;
            }

            if (txtMeal.Text == "Veg Thali")
            {
                radioVegThali.IsChecked = true;
            }

        }


        private void menuQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuInsert_Click(object sender, RoutedEventArgs e)
        {
            addAirline();
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateAirline();
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteAirline();
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
            addAirline();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateAirline();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteAirline();
        }

        //-----------------------------Button ends----------------------------------

        private void addAirline()
        {
            readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);

            bool radiocheck = true;

            MessageBoxResult res = MessageBoxResult.Yes;
            if (readOnly == true)
            {
                MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                            MessageBoxButton.OK, MessageBoxImage.Error);

            }
            //-----------------Radio Buttons Check--------------------
            if ((bool)radioA.IsChecked)
            {

                txtAirplane.Text = "Airbus 320";

            }

            else if ((bool)radioB.IsChecked)
            {

                txtAirplane.Text = "Boeing 777";

            }

            else
            {
                MessageBox.Show("Please Choose One of the following Airplanes", "Invalid Entry",
                            MessageBoxButton.OK, MessageBoxImage.Error);

                radiocheck = false;
            }

            if ((bool)radioSushi.IsChecked)
            {

                txtMeal.Text = "Sushi";

            }

            else if ((bool)radioSalad.IsChecked)
            {

                txtMeal.Text = "Salad";

            }
            else if ((bool)radioVegThali.IsChecked)
            {

                txtMeal.Text = "Veg Thali";

            }

            else
            {
                MessageBox.Show("Please Choose One of the following Meals", "Invalid Entry",
                            MessageBoxButton.OK, MessageBoxImage.Error);

                radiocheck = false;
            }

            //-----------------Radio Buttons Check--------------------

            if (validateInput() && readOnly == false && radiocheck == true)
            {

                var duplicate = from u in collection.getairlinesData()
                                where (txtName.Text == u.Name && txtAirplane.Text == u.Airplane && txtSeats.Text == u.Seatsavailable.ToString() && txtMeal.Text == u.MealAvailable)
                                select u;
                if (duplicate.Any())
                {
                    res = MessageBox.Show("There's a entry of Same Information You Still want to proceed ?", "Same Entry Found",
                            MessageBoxButton.YesNo, MessageBoxImage.Warning);


                }
                if (res == MessageBoxResult.Yes)
                {
                    collection.addairlinesData(new Airlines(collection.getairlinesData().Count + 1001, txtName.Text,
                                    txtAirplane.Text,
                                    int.Parse(txtSeats.Text), txtMeal.Text));

                    var names = from user in collection.getairlinesData()
                                select user.Name;

                    listAirlines.DataContext = names;

                    MessageBox.Show("Airline Added", "Done!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Airline Not Added", "Done!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    txtId.Text = "";
                    txtName.Text = "";
                    txtAirplane.Text = "";
                    txtSeats.Text = "";
                    txtMeal.Text = "";
                }

            }
        }//addAirlines ends

        private void updateAirline()
        {
            
            readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);
            if (readOnly == true)
            {
                MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if ((bool)radioA.IsChecked)
            {

                txtAirplane.Text = "Airbus 320";

            }

            else if ((bool)radioB.IsChecked)
            {

                txtAirplane.Text = "Boeing 777";

            }

            

            if ((bool)radioSushi.IsChecked)
            {

                txtMeal.Text = "Sushi";

            }

            else if ((bool)radioSalad.IsChecked)
            {

                txtMeal.Text = "Salad";

            }
            else if ((bool)radioVegThali.IsChecked)
            {

                txtMeal.Text = "Veg Thali";

            }

            bool valid = (listAirlines.SelectedIndex != -1 ? true : false);

            if (valid == false)
            {
                MessageBox.Show("Please Select Item to UPDATE", "Invalid Attempt",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                
               
                if (validateInput() && readOnly == false)
                {

                    var duplicate = from u in collection.getairlinesData()
                                    where (txtName.Text == u.Name && txtAirplane.Text == u.Airplane && txtSeats.Text == u.Seatsavailable.ToString() && txtMeal.Text == u.MealAvailable)
                                    select u;
                    if (duplicate.Any())
                    {
                        MessageBox.Show("There's a entry of Same Information Please Enter the Differences", "Same Entry Found",
                               MessageBoxButton.OK, MessageBoxImage.Error);


                    }
                    else
                    {


                        Airlines airline = new Airlines(listAirlines.SelectedIndex + 1001, txtName.Text,
                           txtAirplane.Text, int.Parse(txtSeats.Text), txtMeal.Text);
                        collection.updateairlinesData(listAirlines.SelectedIndex + 1001, airline);


                        var names = from user in collection.getairlinesData()
                                    select user.Name;

                        listAirlines.DataContext = names;
                        MessageBox.Show("Airline Updated", "Done!!!",
                                MessageBoxButton.OK, MessageBoxImage.Information);

                        txtId.Text = "";
                        txtName.Text = "";
                        txtAirplane.Text = "";
                        txtSeats.Text = "";
                        txtMeal.Text = "";
                    }
                }
            }
        }//updateAirlines ends

        private void deleteAirline()
        {
            readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);
            if (readOnly == true)
            {
                MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }

            bool valid = (listAirlines.SelectedIndex != -1 ? true : false);

            if (valid == false)
            {
                MessageBox.Show("Please Select Item to DELETE", "Invalid Attempt",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (readOnly == false)
            {

                collection.deleteairlinesData(listAirlines.SelectedIndex + 1001);
                Airlines airline = new Airlines();
                int count = collection.getairlinesData().Count;
                for (int i = 0; i <count ; i++)
                {
                    collection.deleteLastairlinesData(out airline);
                    airline.Id = i +1001;
                    collection.addairlinesData(airline);
                    //collection.updateCustId(i, i + 101);
                }
                var names = from user in collection.getairlinesData()
                            select user.Name;

                listAirlines.DataContext = names;
                MessageBox.Show("Airline Deleted", "Done!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                txtId.Text = "";
                txtName.Text = "";
                txtAirplane.Text = "";
                txtSeats.Text = "";
                txtMeal.Text = "";
            }
        }//deleteAirline ends

        private bool validateInput()
        {
            bool valid = true;
            if (txtId.Text == "" || txtName.Text == "" ||
               txtAirplane.Text == "" || txtSeats.Text == "" || txtMeal.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }

            else
            {


            try
            {
                int temp = int.Parse(txtSeats.Text);

            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please Enter NUMBER as  Seats", "Invalid Entry",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }

            
            }

            return valid;
        }//ends validateInput Method

    }//ends class
}
