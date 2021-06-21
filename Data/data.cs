using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data
{
    public class DataView 
    {
        
        public void customerMenu()
        {
            Console.WriteLine("What would you like to do?\n");
            //List store products
            Console.WriteLine("\t\t1.List products\n");
            //order items and all items are added to an order list and dated
            Console.WriteLine("\t\t2.Order Item\n");
            //previous order
            Console.WriteLine("\t\t4.Last order\n");
            //all orders
            Console.WriteLine("\t\t5.Order History\n");
            Console.ReadLine();
        }

        public void adminMenu(int errVal = 1)
        {
            int option;
            string errMessage;
            Console.Clear();
            if(errVal == 0) errMessage = "Error enter a valid option number!\nEnter 1 or 2:";
            else errMessage = "Enter 1 or 2:";
            
            Console.WriteLine("What would you like to do?\n");
            //shows orders made, with customerid, prodId, DateOfOrder, totalPrice
            Console.WriteLine("\t\t1.List orders\n");
            //List all registered customers and admins
            Console.WriteLine("\t\t2.List users\n");
            Console.WriteLine("\t\t3.List all products and details\n");
            Console.WriteLine("\t\t4.Add product to inventory\n");
            Console.WriteLine("\t\t5.Update product\n");
            Console.WriteLine("\t\t6.Remove user\n");
            Console.WriteLine("\t\t7.Delete order\n");
            Console.WriteLine(errMessage);
            
            try
            {
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                        Console.WriteLine("option 1 chosen!");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("option 2 chosen!");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("option 3 chosen!");
                        Console.ReadLine();
                        break;
                    case 4:
                        AddProduct();
                        break;
                    case 5:
                        Console.WriteLine("option 5 chosen!");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("option 6 chosen!");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("option 7 chosen!");
                        Console.ReadLine();
                        break;
                }
            }
            catch (System.Exception)
            {
                Console.Clear();
                adminMenu(0);
                throw;
            }
            
        }

        private void AddProduct() {
            string name;
            string supplier;
            string type;
            int stockLevel;
            int option;

            //maybe adding a confirmation per readline to make sure data is correct

            while(true) {
                Console.WriteLine("Awesome!! Time to add a new product!");
                Console.WriteLine("Enter Product name:");
                name = Console.ReadLine();
                if(strDataConfimation(name, "name")) break;
                else continue;
            }
            while(true)
            {
                Console.WriteLine("Enter Product supplier:");
                supplier = Console.ReadLine();
                if(strDataConfimation(supplier, "supplier")) break;
                else continue;
            }
            while(true)
            {
                Console.WriteLine("Enter Product type:");
                Console.WriteLine("'Food' or 'Drink'");
                type = Console.ReadLine();
                if(strDataConfimation(type, "type")) break;
                else continue;
            }
            while(true)
            {
                Console.WriteLine("Enter current stock level of product:");
                stockLevel = int.Parse(Console.ReadLine());
                if(intDataConfimation(stockLevel, "quantity in stock")) break;
                else continue;
            }
            Console.WriteLine("Success!");


        }

        private bool strDataConfimation(string data = "NULL", string dataKey = "NULL", int errVal = 1)
        {
            string option;
            string errMessage;
            Console.Clear();
            if(errVal == 0) errMessage = "Error enter 'Y' or 'N'...";
            else errMessage = "Enter 'Y' or 'N':";
            if(data != "NULL" && dataKey != "NULL")
            {
                Console.WriteLine("You entered " + data + " as the product " + dataKey + "\nIs this correct?");
                Console.WriteLine("Y or N");
                try
                {
                    option = Console.ReadLine();
                    switch(option)
                    {
                        case "Y":
                            return true;
                            break;
                        case "N":
                            return false;
                            break;
                        case "y":
                            return true;
                            break;
                        case "n":
                            return false;
                            break;
                    }
                }
                catch (System.Exception)
                {
                    Console.Clear();
                    strDataConfimation(data, dataKey, 0);
                    throw;
                }
            }
            return false;
        }

        private bool intDataConfimation(int val = 0,string valKey = "NULL", int errVal = 1)
        {
            string option;
            string errMessage;
            Console.Clear();
            if(errVal == 0) errMessage = "Error enter 'Y' or 'N'...";
            else errMessage = "Enter 'Y' or 'N':";
            if(val != 0 && valKey != "NULL")
            {
                Console.WriteLine("You entered " + val + " as the product " + valKey + "\nIs this correct?");
                Console.WriteLine("Y or N");
                try
                {
                    option = Console.ReadLine();
                    switch(option)
                    {
                        case "Y":
                            return true;
                            break;
                        case "N":
                            return false;
                            break;
                        case "y":
                            return true;
                            break;
                        case "n":
                            return false;
                            break;
                    }
                }
                catch (System.Exception)
                {
                    Console.Clear();
                    intDataConfimation(val, valKey, 0);
                    throw;
                }
            }
            return false;
        }
    }
}