using System;
using System.Collections.Generic;

namespace WPF_HW1.Model
{
    public class User
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public string _surname { get; set; }
        public string _username { get; set; }
        public string _email { get; set; }
        public string _password { get; set; }

        public List<TimeClock> _timeClocks { get; set; }

        public User(int id, string name, string surname, string username, string email, string password, List<TimeClock> timeClocks)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _username = username;
            _email = email;
            _password = password;
            _timeClocks = timeClocks;
        }

        public User()
        {

        }

    }
}
