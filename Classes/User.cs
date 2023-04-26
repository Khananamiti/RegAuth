using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestrV
{
    internal class User
    {
        public int id { get; set; }

        private string role, fio, login, pass;

        public string Role {
            get { return role; }
            set { role = value; } 
        }

        public string Fio
        {
            get { return fio; }
            set { fio = value; } 
        }
        
        public string Login {
            get { return login; }
            set { login = value; } 
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; } 
        }

        public User() { }
        public User(string role, string fio, string login, string pass) {
            this.role = role;
            this.fio = fio;
            this.login = login;
            this.pass = pass;
        }

        public override string ToString() { 
            return "Пользователь: " + Login + ". Password: " + Pass;
        }
    }
    internal class Order
    {
        public int id { get; set; }
        public string description { get; set; }
        public string order_date { get; set; }
        public string delivery_date { get; set; }
        public string delivery_point { get; set; }
        public string receiver_full_name { get; set; }
        public string receive_code { get; set; }
        public string status { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
