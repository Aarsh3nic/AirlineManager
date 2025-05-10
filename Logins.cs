using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_CS
{
    class Logins
    {
        private int id;
        private string username;
        private string password;
        private int superuser;
        
        public Logins(int id, string username, string password, int superuser)
        {
            Id = id;
            Username = username;
            Password = password;
            Superuser = superuser;
        }

        public Logins()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Superuser { get => superuser; set => superuser = value; }


        Dictionary<string, Logins> userData = new Dictionary<string, Logins>();

        public void addUserData(string username,Logins userlogin)
        {
            userData.Add(username,userlogin);
        }

        public Dictionary<string, Logins> getUserData()
        {
            Dictionary<string, Logins> userInfo = new Dictionary<string, Logins>();

            foreach (var user in userData)
            {
                userInfo.Add(user.Key,user.Value);
            }

            return userInfo;
        }

        public void deleteUserData(string username)
        {
            userData.Remove(username);
        }

       

    }//ends class
}
