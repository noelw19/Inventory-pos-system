using System;

namespace menuView
{
    public class MenuView 
    {
        int custId;

//------------------------------CUSTOMER MENU CODE---------------------------------
        public void customerMenu(int id, int errVal = 1)
        {
            this.custId = id;
            int option;
            string errMessage;
            if(errVal == 0) errMessage = "Error enter valid line number!";
            else errMessage = "Enter corresponding line number";
            Console.WriteLine("What would you like to do?\n");
            //List store products
            Console.WriteLine("\t\t1.List products_WORKING\n");
            //order items and all items are added to an order list and dated
            Console.WriteLine("\t\t2.Order Item--WORKING\n");
            //previous order
            Console.WriteLine("\t\t3.Last order--WORKING\n");
            //all orders
            Console.WriteLine("\t\t4.Order History__WORKING\n");
            Console.WriteLine("\t\t5.Log out\n");
            Console.WriteLine("{0}", errMessage);
            
            try
            {
                OrderInformation oi = OrderInformation.Instance();
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        printProd();
                        customerMenu(this.custId);
                        break;
                    case 2:
                        printProd();
                        order();
                        customerMenu(this.custId);
                        break;
                    case 3:
                        oi.Load();
                        Console.Clear();
                        oi.PrintLatest(this.custId);
                        Console.WriteLine("Press Enter to continue....");
                        Console.ReadLine();
                        customerMenu(this.custId);
                        break;
                    case 4:
                        oi.Load();
                        Console.SetCursorPosition(0, 0);
                        oi.PrintMyOrders(this.custId);
                        Console.WriteLine("Press Enter to continue....");
                        Console.ReadLine();
                        customerMenu(this.custId);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Logged out...");
                        break;
                }
            }
            catch (System.Exception)
            {
                Console.Clear();
                customerMenu(this.custId, 0);
                throw;
            }
        }

        public void order()
        {
            int custId = this.custId;
            int[] prodId = new int[15];
            string readme;
            int Match = 0;
            DateTime date = DateTime.Now;
            ProductInformation pi = ProductInformation.Instance();
            pi.Load();

            //maybe adding a confirmation per readline to make sure data is correct

            while(true) {
                Console.WriteLine('\n' + "Awesome!! Time to Order items!");
                Console.WriteLine("Enter Product id:");
                readme = Console.ReadLine();
                if(readme == "End" || readme == "end") {
                    break;
                } else {
                    if(intDataConfimation(int.Parse(readme), "Id")) {
                        if(int.Parse(readme) != 0)
                        {
                            prodId[Match] = int.Parse(readme);
                            Match++;
                            continue;
                        }
                    }
                    else {
                        Console.WriteLine("Error only enter numbers");
                        continue;
                }}
            }
            
            var oi = OrderInformation.Instance();
            // int MatcherForStockUpdate = 0;
            // string[] productNameAndAmount;
            string[] prodNames = new string[prodId.Length];
            int[] prodAmounts = new int[prodId.Length];
            int[] newProdId = new int[prodId.Length];
            int instanceMatch = 0;

            // -------for loop to check find how many of each product was bought----
            for (int i = 0; i < prodId.Length; i++)
            {
                int prodMatch = 0;
                int choice = prodId[i];
                for (int j = 0; j < prodId.Length; j++)
                {
                    //if a match is found between the item searching for and the array to check
                    if(prodId[i] == prodId[j]) {
                        //1 is addded to instance match to show the amount of times this
                        //product has been ordered within this order instance.
                        instanceMatch++;
                        //the first instance where the searching for items is found it is 
                        //added to the new prod id array, to show it has been ordered
                        if(prodMatch == 0) {
                            newProdId[prodMatch] = prodId[i];
                        }
                        //prodMatch updated to onliy add the first instance of the product.
                        prodMatch++;
                        }
                    if(prodId[i] == prodId[j] && prodMatch > 1 && i < j) {
                        instanceMatch--;
                        //FINISH CODE HERE------------------------------------------------------------------------------------------------------------
                    }
                }

                prodAmounts[i] = instanceMatch;
                instanceMatch = 0; 
                prodMatch = 0;
                
            }
            
            for (int i = 0; i < prodAmounts.Length; i++)
            {
                Console.WriteLine("Amount: {0}" + '\n' + "Id: {1}", prodAmounts[i], newProdId[i]);
            }
            oi.AddOrder(oi.ProdCount(), custId, newProdId, prodAmounts, date);
            oi.Save();
            oi.Load();
            oi.PrintMyOrders(custId);
            Console.ReadLine();
            
            Console.WriteLine("Returning to menu....");
        }

        public void printProd(){
                ProductInformation pi = ProductInformation.Instance();
                pi.Load();
                Console.Clear();
                pi.Print();
                Console.WriteLine("\nPress Enter to continue....");                    
                Console.ReadLine();
        }



// -----------------------------ADMINISTRATOR MENU CODE---------------------------------
        
        public void adminMenu(int errVal = 1)
        {
            int option;
            string errMessage;
            Console.Clear();
            if(errVal == 0) errMessage = "Error enter a valid option number!\nEnter corresponding number:";
            else errMessage = "Enter corresponding number:";
            
            Console.WriteLine("What would you like to do?\n");
            //shows orders made, with customerid, prodId, DateOfOrder, totalPrice
            Console.WriteLine("\t\t1.List orders -WORKING\n");
            //List all registered customers and admins
            Console.WriteLine("\t\t2.List users -WORKING\n");
            Console.WriteLine("\t\t3.List all products and details -WORKING\n");
            Console.WriteLine("\t\t4.Add product to inventory -WORKING\n");
            Console.WriteLine("\t\t5.Update product\n");
            Console.WriteLine("\t\t6.Remove user -WORKING\n");
            Console.WriteLine("\t\t7.Remove product from catalog\n");
            Console.WriteLine("\t\t8.Delete order -Working\n");
            Console.WriteLine("\t\t9.Logout -WORKING\n");
            Console.WriteLine(errMessage);
            
            try
            {
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                        OrderInformation oi = OrderInformation.Instance();
                        oi.Load();
                        Console.WriteLine("\n--------------------ALL ORDERS--------------------\n\n");
                        oi.Print();
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadLine();
                        adminMenu();
                        break;
                    case 2:
                        CustomerInformation ci = CustomerInformation.Instance();
                        AdminInformation ai = AdminInformation.Instance();
                        ci.Load();
                        ai.Load();
                        Console.WriteLine("\n\t\t========Admins========");
                        ai.Print();
                        Console.WriteLine("\t\t========Customers========");
                        ci.Print();
                        Console.WriteLine("Press Enter to continue....");
                        Console.ReadLine();
                        adminMenu();
                        break;
                    case 3:
                        ProductInformation pi = ProductInformation.Instance();
                        pi.Load();
                        Console.Clear();
                        pi.Print();
                        Console.WriteLine("\nPress Enter to continue....");
                        Console.ReadLine();
                        adminMenu();
                        break;
                    case 4:
                        AddProduct();
                        break;
                    case 5:
                        Console.WriteLine("option 5 chosen!");
                        Console.ReadLine();
                        break;
                    case 6:
                        removeUser();
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("option 7 chosen!");
                        Console.ReadLine();
                        break;
                    case 8:
                        deleteOrder();
                        adminMenu();
                        break;
                    case 9:
                        // View view = new View();
                        Console.Clear();
                        Console.WriteLine("Logged out...");
                        //arg 1 to show that it has not been called from an error
                        // view.loginScreen(2);
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

        private void deleteOrder()
        {
            printOrders();
            Console.WriteLine("Please enter order Id to remove that order..." + '\n' + "Type cancel to go back...");
            string option = Console.ReadLine();
            int intValue;
            //tryparse checks if the first arg can be converted to int then stores the converted value
            //within the intValue interger variable
            try
            {
                bool isInt = int.TryParse(option, out intValue);
            if(isInt){ 
                OrderInformation oi = OrderInformation.Instance();
                string option1;
                oi.Load();
                oi.PrintById(intValue);
                Console.WriteLine("Are you sure you want to remove this order?" + '\n' + "Y or N");
                option1 = Console.ReadLine();
                if(oi.checkValidId(intValue)) {
                    switch (option1)
                    {
                        case "Y":
                            oi.RemoveOrder(intValue);
                            oi.Save();
                            break;
                        case "N":
                            deleteOrder();
                            break;
                        case "y":
                            oi.RemoveOrder(intValue);
                            oi.Save();
                            break;
                        case "n":
                            deleteOrder();
                            break;
                    }
                };
                Console.WriteLine("Returning to menu...");
                adminMenu();
            }
            switch (option)
            {
                case "cancel":
                    Console.Clear();
                    adminMenu();
                    break;
            }
            }
            catch (System.Exception)
            {
                adminMenu();
                throw;
            }
        }

        private void printOrders()
        {
            OrderInformation oi = OrderInformation.Instance();
            oi.Load();
            oi.Print();

        }

        private void removeUser(int errVal = 1)
        {
            string errMessage = "";
            int option;
            if(errVal == 0) errMessage = "Error enter valid option..";
            Console.WriteLine("Remove: \n\t1.Administrator\n\t2.Customer");
            {if(errVal == 0) Console.WriteLine(errMessage);}
            try
            {
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AdminInformation ai = AdminInformation.Instance();
                        string adminName;
                        ai.Load();
                        Console.WriteLine("Enter the username of the admin acMatch to remove:");
                        adminName = Console.ReadLine();
                        ai.RemoveAdmin(adminName);
                        ai.Save();
                        ai.Print();
                        Console.WriteLine("Press Enter to continue....");
                        Console.ReadLine();
                        adminMenu();
                        break;
                    case 2:
                        CustomerInformation ci = CustomerInformation.Instance();
                        string custName;
                        ci.Load();
                        Console.WriteLine("Enter the username of the customer acMatch to remove:");
                        custName = Console.ReadLine();
                        ci.RemoveCustomer(custName);
                        ci.Save();
                        ci.Print();
                        Console.WriteLine("Press Enter to continue....");
                        Console.ReadLine();
                        adminMenu();
                        break;
                }
            }
            catch (System.Exception)
            {
                Console.Clear();
                removeUser(0);
                throw;
            }

        }

        private void AddProduct() {
            string name;
            string supplier;
            string type;
            int stockLevel;

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
            ProductInformation pi = ProductInformation.Instance();
            pi.Load();
            pi.AddProduct(pi.ProdCount(), name, type, supplier, stockLevel);
            pi.Save();
            pi.Print();
            Console.ReadLine();
            
            Console.WriteLine("Returning to admin menu....");
            adminMenu();
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
                Console.WriteLine(errMessage);
                try
                {
                    option = Console.ReadLine();
                    switch(option)
                    {
                        case "Y":
                            return true;
                        case "N":
                            return false;
                        case "y":
                            return true;
                        case "n":
                            return false;
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
            Console.Clear();
            string errMessage;
            if(errVal == 0) errMessage = "Error enter 'Y' or 'N'...";
            else errMessage = "Enter 'Y' or 'N':";
            if(val != 0 && valKey != "NULL")
            {
                Console.WriteLine("You entered " + val + " as the product " + valKey + "\nIs this correct?");
                Console.WriteLine(errMessage);
                try
                {
                    option = Console.ReadLine();
                    switch(option)
                    {
                        case "Y":
                            return true;
                        case "N":
                            return false;
                        case "y":
                            return true;
                        case "n":
                            return false;
                        default:
                            return true;
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