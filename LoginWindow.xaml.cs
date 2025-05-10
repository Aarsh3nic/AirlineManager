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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        Collections collection = new Collections(); 
       // Logins lg = new Logins();

        
        public LoginWindow()
        {
            InitializeComponent();
            
            collection.addUserData("pateaars",new Logins(10,"pateaars","pwdpateaars",1));
            collection.addUserData("patelsuj", new Logins(11, "patelsuj", "pwdpatelsuj", 1));
            collection.addUserData("shahmox", new Logins(12, "shahmox", "pwdshahmox", 0));
            collection.addUserData("desaipu", new Logins(13, "desaipu", "pwddesaipu", 0));
            collection.addUserData("nishtpat", new Logins(14, "nishtpat", "pwdnishtpat", 1));

            tbUser.Focus();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;
 
                if(tbUser.Text == "")
                {
                    MessageBox.Show("Please Enter Username", "Invalid Entry",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }
                if (pbPass.Password == "")
                {
                    MessageBox.Show("Please Enter Password", "Invalid Entry",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }
                
                if (txtId.Text == "")
                {
                    MessageBox.Show("Please Enter Id", "Invalid Entry",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
            }
                else
                {
                    try
                    {
                        int temp = int.Parse(txtId.Text);

                    }
                    catch(System.FormatException)
                    {
                        MessageBox.Show("Please Enter NUMBER as  Id", "Invalid Entry",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                    valid = false;
                }
                }
                if (txtSuperUser.Text == "")
                {
                    MessageBox.Show("Please Enter SuperUser-Entry", "Invalid Entry",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                valid = false;
                }
                else
                {
                    try
                    {
                        int temp = int.Parse(txtSuperUser.Text);

                    }
                    catch (System.FormatException)
                    {
                        MessageBox.Show("Please Enter NUMBER as SuperUser-Entry", "Invalid Entry",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                    valid = false;
                    }
                }


            //foreach (var user in collection.getUserData())
            //{
            //if ((user.Value.Username == tbUser.Text) && (user.Value.Password == pbPass.Password) && (user.Value.Id.ToString() == txtId.Text) && (user.Value.Superuser.ToString() == txtSuperUser.Text))
            //{
            //     valid = true;
            //}
            //}

            if (valid)
            {
                var verify = from user in collection.getUserData()
                             where (user.Value.Username == tbUser.Text) && (user.Value.Password == pbPass.Password) && (user.Value.Id.ToString() == txtId.Text) && (user.Value.Superuser.ToString() == txtSuperUser.Text)
                             select user;


                if (verify.Any())
                {
                    HomePage hp = new HomePage();
                    hp.lblMode.Content = (int.Parse(txtSuperUser.Text) == 1 ? "Super User Mode" : "Regular User Mode");
                    hp.Title = "Welcome";
                    hp.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password or Id or SuperUser-Entry", "Login Failed",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }// ends class
}
