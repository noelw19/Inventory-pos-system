
using System;
using System.Collections.Generic;
using System.Text;

namespace B0Layer
{
    [Serializable]
    public class Customer
    {

        private string username;
        private int id = 0;
        private string  pin;
        private string  name;
        // Data members for Customer class
        public Customer(int id, string name, string username, string pin) {
            this.id = id + 1;
            this.name = name;
            this.username = username;
            this.pin = pin;
        }

        public int Id { get
            {
                return this.id;
            } set
            {
                this.id = value;
            } }

        public string Username 
        { 
            get
            {
                return this.username;
            } 
            set
            {
                this.username = value;
            }
        }

        public string Pin 
        { 
            get
            {
                return this.pin;
            }
            set
            {
                this.pin = value;
            }
        }
        public string Name 
        { 
            get
            {
                return this.name;
            } 
            set
            {
                this.name = value;
            }
        }
        public string AccountType { get; set; }
        public int Balance { get; set; }
        public string Status { get; set; }
        public int AccountNo { get; set; }



    }
}