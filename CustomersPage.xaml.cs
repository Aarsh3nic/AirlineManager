using Microsoft.VisualBasic;
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
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Window
    {

        Collections collection = new Collections();
        private bool readOnly = false;
        public CustomersPage()
        {
            InitializeComponent();

            collection.getCustomerCollection();

            var names = from user in collection.getCustomerData()
                        select user.Name;
            listCustomers.DataContext = names;

            //this.readOnly = (lblMode.Content.ToString() == "Regular User Mode"?true:false);

            //lblreadOnly.Content = readOnly.ToString();
            //if (lblMode.Content.ToString() == "Regular User Mode")
            //{
            //    readOnly = true;

            //    lblreadOnly.Content = readOnly.ToString();
            //}




            //btnInsert.IsEnabled = false;
            //btnUpdate.IsEnabled = false;
            //btnDelete.IsEnabled = false;

            //menuInsert.IsEnabled = false;



        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listCustomers.SelectedIndex +101;


            var selectedCustomers = from user in collection.getCustomerData()
                               where user.Id == index
                               select user;

            foreach (var sc in selectedCustomers)
            {
                txtId.Text = sc.Id.ToString();
                txtName.Text = sc.Name;
                txtAddress.Text = sc.Address;
                txtEmail.Text = sc.Email;
                txtPhone.Text = sc.Phone;
            }
        }


        private void menuQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuInsert_Click(object sender, RoutedEventArgs e)
        {
            addCustomer();
        }

        private void menuUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateCustomer();
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteCustomer();
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
            addCustomer();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateCustomer();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteCustomer();
        }

        //-----------------------------Button ends----------------------------------

        private void addCustomer()
        {
            readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);

            

            MessageBoxResult res = MessageBoxResult.Yes;
            if (readOnly == true)
            {
                MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
                if (validateInput() && readOnly == false) {

                var duplicate = from u in collection.getCustomerData()
                                where (txtName.Text == u.Name && txtAddress.Text == u.Address && txtEmail.Text == u.Email && txtPhone.Text == u.Phone)
                                select u;
                if (duplicate.Any())
                {
                    res =  MessageBox.Show("There's a entry of Same Information You Still want to proceed ?", "Same Entry Found",
                            MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    
                }
                if (res == MessageBoxResult.Yes) {
                    collection.addCustomerData(new Customer(collection.getCustomerData().Count + 101, txtName.Text,
                                    txtAddress.Text, txtEmail.Text,
                                    txtPhone.Text));

                    var names = from user in collection.getCustomerData()
                                select user.Name;

                    listCustomers.DataContext = names;
                    MessageBox.Show("Customer Added", "Done!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Customer Not Added", "Done!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    txtId.Text = "";
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";
                    txtPhone.Text = "";
                }
                    
                }
            
        }//addCustomer ends

        private void updateCustomer()
        {
            readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);
            if (readOnly == true)
            {
                MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }

            bool valid = (listCustomers.SelectedIndex != -1 ? true : false);

            if (valid == false)
            {
                MessageBox.Show("Please Select Item to UPDATE", "Invalid Attempt",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (validateInput() && readOnly == false)
                {
                    var duplicate = from u in collection.getCustomerData()
                                    where (txtName.Text == u.Name && txtAddress.Text == u.Address && txtEmail.Text == u.Email && txtPhone.Text == u.Phone)
                                    select u;
                    if (duplicate.Any())
                    {
                        MessageBox.Show("There's a entry of Same Information Please Enter the Differences", "Same Entry Found",
                               MessageBoxButton.OK, MessageBoxImage.Error);


                    }
                    else
                    {


                        Customer cust = new Customer(listCustomers.SelectedIndex + 101, txtName.Text,
                           txtAddress.Text, txtEmail.Text, txtPhone.Text);
                        collection.updatecustomerData(listCustomers.SelectedIndex, cust);


                        var names = from user in collection.getCustomerData()
                                    select user.Name;

                        listCustomers.DataContext = names;
                        MessageBox.Show("Customer Updated", "Done!!!",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        txtId.Text = "";
                        txtName.Text = "";
                        txtEmail.Text = "";
                        txtAddress.Text = "";
                        txtPhone.Text = "";
                    }
                }
            }
        }//updateCustomer ends
        private void deleteCustomer()
        {
            readOnly = (lblMode.Content.ToString() == "Regular User Mode" ? true : false);
            if (readOnly == true)
            {
                MessageBox.Show("Function is not allowed to Regular User", "Not Accesible",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }

            bool valid = (listCustomers.SelectedIndex != -1 ? true : false);

            if (valid == false)
            {
                MessageBox.Show("Please Select Item to DELETE", "Invalid Attempt",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (readOnly  == false)
            {

                collection.deletecustomerData(listCustomers.SelectedIndex + 101);


                for (int i = 0; i < collection.getCustomerData().Count; i++)
                {

                    collection.updateCustId(i, i + 101);
                }
                var names = from user in collection.getCustomerData()
                            select user.Name;

                listCustomers.DataContext = names;
                MessageBox.Show("Customer Deleted", "Done!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                txtId.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";
            }
        }//ends deleteCustomer
        private bool validateInput()
        {
            bool valid = true;
            if (txtId.Text == "" || txtName.Text == "" ||
               txtAddress.Text == "" || txtEmail.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }

            //else
            //{


                //try
                //{
                //    int temp = int.Parse(txtId.Text);

                //}
                //catch (System.FormatException)
                //{
                //    MessageBox.Show("Please Enter NUMBER as  Id", "Invalid Entry",
                //            MessageBoxButton.OK, MessageBoxImage.Error);
                //    valid = false;
                //}

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
