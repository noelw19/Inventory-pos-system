using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using B0Layer;

namespace ViewLayer
{
    public class View 
    {
        public void loginScreen()
        {
            CustomerInformation ci = CustomerInformation.Instance();
            Console.Clear();
            ci.Load();
            ci.Print();
            int ch;
            Console.WriteLine("-----Inventory System-----\n\n" +
                            "What do you want to do:\n" +
                            "1----Register----\n" +
                            "2----Login----\n\n" +
                            "Enter 1 or 2:");

            
            ch = int.Parse(Console.ReadLine());
            switch (ch) 
            {
                case 1:
                    Console.Clear();
                    registerCustomer();
                    break;
                case 2:
                    Console.Clear();
                    login();
                    break;

            }

        }

        public void login() 
        {
            int ch;
            string username;
            string pin;
            Console.Clear();
            Console.WriteLine("-----Welcome to ATM-----\n\n" +
                            "Login as:\n" +
                            "1----Administrator----\n" +
                            "2----Customer----\n\n" +
                            "Enter 1 or 2:");
            ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    AdminInformation ai = AdminInformation.Instance();
                    ai.Load();
                    Console.WriteLine("Enter admin username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter admin pin: ");
                    pin = Console.ReadLine();
                    if(ai.CheckCredentials(username, pin))
                    {
                        Console.Clear();
                        Console.WriteLine("Login success!");
                        Admin_Welcome(username);
                    } else {
                        Console.WriteLine("Error " + username + ": " + pin + "invalid");
                    }
                    break;
                case 2:
                    CustomerInformation ci = CustomerInformation.Instance();
                    ci.Load();
                    Console.WriteLine("Enter username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter pin: ");
                    pin = Console.ReadLine();
                    if(ci.CheckCredentials(username, pin))
                    {
                        Console.Clear();
                        Console.WriteLine("Login success!");
                        Customer_Welcome(username);
                    } else {
                        Console.WriteLine("Error " + username + ": " + pin + "invalid");
                    }
                    break;
            }

        }

        public void registerCustomer() 
        {
            string pin;
            string username;
            string name;
            int ch;
            Console.Clear();
            Console.WriteLine("-----Welcome to ATM-----\n\n" +
                            "Register as:\n" +
                            "1----Administrator----\n" +
                            "2----Customer----\n\n" +
                            "Enter 1 or 2:");
            ch = int.Parse(Console.ReadLine());
            
            switch(ch) {
                case 1:
                    AdminInformation ai = AdminInformation.Instance();

                    Console.Clear();
                    Console.WriteLine("\t\t========Register as Administrator========");
                    Console.WriteLine("Enter name");
                    username = Console.ReadLine();

                    Console.WriteLine("Enter pin");
                    pin = Console.ReadLine();
                    ai.AddAdmin(username, pin);
                    ai.Save();
                    ai.Load();
                    ai.Print();

                    break;
                case 2: 

                    CustomerInformation ci = CustomerInformation.Instance();
                    
                    Console.Clear();
                    Console.WriteLine("\t\t========Register as Customer========");
                    Console.WriteLine("Enter first name");
                    name = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("\t\t========Register as Customer========");
                    Console.WriteLine("Enter username");
                    username = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("\t\t========Register as Customer========");
                    Console.WriteLine("Enter pin");
                    pin = Console.ReadLine();
                    ci.AddFriend(name, username, pin);
                    ci.Save();
                    ci.Load();
                    ci.Print();
                    break;
            }
        }

        public void Admin_Welcome(string username) 
        {
            Console.WriteLine("\n\t===========Welcome " + username + "===========\n");
        }

        public void Customer_Welcome(string username)
        {
            Console.WriteLine("\n\t===========Welcome " + username + "===========\n");
        }
    }
}