using System;
using menuView;

namespace LoginView
{
    public class Login 
    {
        public void loginScreen(int errVal)
        {
            if(errVal == 1) Console.Clear();
            CustomerInformation ci = CustomerInformation.Instance();
            ci.Load();
            int ch;
            string errMessage = "Enter 1 or 2:";
            if(errVal == 0) errMessage = "Error enter a valid option number!\nEnter 1 or 2:";
            

            Console.WriteLine("-----Inventory System-----\n\n" +
                            "What do you want to do:\n" +
                            "1----Register----\n" +
                            "2----Login----\n\n" +
                            errMessage);
            
            
            try
            {
                ch = int.Parse(Console.ReadLine());
                switch (ch) 
                {
                    case 1:
                        Console.Clear();
                        registerCustomer(1);
                        break;
                    case 2:
                        Console.Clear();
                        login(1);
                        break;

                }
            }
            catch (System.Exception)
            {
                Console.Clear();
                loginScreen(0);
                throw;
            }

        }

        public void login(int errVal) 
        {
            int ch;
            string username;
            string pin;
            string errMessage;
            Console.Clear();
            if(errVal == 0) errMessage = "Error enter a valid option number!\nEnter 1 or 2:";
            else errMessage = "Enter 1 or 2:";

            Console.WriteLine("-----Welcome to ATM-----\n\n" +
                            "Login as:\n" +
                            "1----Administrator----\n" +
                            "2----Customer----\n\n" +
                            errMessage);
            
            try
            {
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
                        Console.WriteLine("Error " + username + ": " + pin + "is invalid\nPress enter to continue....");
                        Console.ReadLine();
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
                        Console.WriteLine("Error " + username + ": " + pin + " is invalid\nPress enter to continue....");
                        Console.ReadLine();
                        
                    }
                    break;
            }
            }
            catch (System.Exception)
            {
                Console.Clear();
                login(0);
                throw;
            }

        }

        public void registerCustomer(int errVal) 
        {
            string pin;
            string username;
            string name;
            int ch;
            string errMessage;
            Console.Clear();
            if(errVal == 0) errMessage = "Error enter a valid option number!\nEnter 1 or 2:";
            else errMessage = "Enter 1 or 2:";
            Console.WriteLine("-----Welcome to ATM-----\n\n" +
                            "Register as:\n" +
                            "1----Administrator----\n" +
                            "2----Customer----\n\n" +
                            errMessage);
            try
            {
                ch = int.Parse(Console.ReadLine());
            switch(ch) {
                case 1:
                    AdminInformation ai = AdminInformation.Instance();
                    ai.Load();

                    Console.Clear();
                    Console.WriteLine("\t\t========Register as Administrator========");
                    Console.WriteLine("Enter name");
                    username = Console.ReadLine();

                    Console.WriteLine("Enter pin");
                    pin = Console.ReadLine();
                    ai.AddAdmin(username, pin);
                    ai.Save();
                    ai.Print();
                    Console.ReadLine();
                    break;
                case 2: 

                    CustomerInformation ci = CustomerInformation.Instance();
                    
                    ci.Load();
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
                    ci.AddFriend(ci.ProdCount(), name, username, pin);
                    ci.Save();
                    ci.Print();
                    Console.ReadLine();
                    break;
            }
            }
            catch (System.Exception)
            {
                Console.Clear();
                registerCustomer(0);
                throw;
            }
        }

        public void Admin_Welcome(string username) 
        {
            Console.WriteLine("\n\t===========Welcome " + username + "===========\n");
            MenuView view = new MenuView();
            view.adminMenu();
            
        }

        public void Customer_Welcome(string username)
        {
            CustomerInformation ci = CustomerInformation.Instance();
            ci.Load();
            string name = ci.getName(username);
            int id = ci.getId(username);
            Console.WriteLine("\n\t===========Welcome " + name + "===========\n");
            MenuView view = new MenuView();
            view.customerMenu(id);
        }
    }
}