using System;
using System.Collections.Generic;
using System.Text;

namespace B0Layer
{
    [Serializable]
    public class Admin
    {
        private string username;
        private string pin;
        
        public Admin(string username, string pin) {
            this.username = username;
            this.pin = pin;
        }
        public string Username 
        { 
            get {return this.username;} 
            set {this.username = value;}
        }
        public string Pin 
        { 
            get{return this.pin;}
            set{this.pin = value;}
        }
    }
}