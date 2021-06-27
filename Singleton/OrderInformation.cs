using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using B0Layer;
 
public class OrderInformation
{
 
    //COMPLETE FILLING THIS CODE OUT FOR ORDER INFO CLASS

    private static OrderInformation orderInformation;
 
    private Dictionary<int, Order> orderDictionary;
    private BinaryFormatter formatter;
 
    private const string DATA_FILENAME = "orderinformation.dat";
 
    public static OrderInformation Instance()
    {
        if (orderInformation == null) {
            orderInformation = new OrderInformation();
        } // end if
 
        return orderInformation;
    } // end public static FriendsInformation Instance()
 
    private OrderInformation()
    {
        // Create a Dictionary to store friends at runtime
        this.orderDictionary = new Dictionary<int, Order>();
        this.formatter = new BinaryFormatter();
    } // end private FriendsInformation()
 
    public void AddOrder(int id, int customerId, int[] productIds, int[] orderAmounts, DateTime date)
    {
        // If we already had added a friend with this name
        if (this.orderDictionary.ContainsKey(id))
        {
            Console.WriteLine("ID has been used already");
        }
        // Else if we do not have this friend details 
        // in our dictionary
        else
        {
            // Add him in the dictionary
            this.orderDictionary.Add(id, new Order(id, customerId, productIds, orderAmounts, date));
            Console.WriteLine("Order successful.");
        } // end if
    } // end public bool AddFriend(string name, string email)
    public void RemoveOrder(int id)
    {
        // If we do not have a friend with this name
        if (!this.orderDictionary.ContainsKey(id -1))
        {
            Console.WriteLine("this id: " + id + " is not an order id.");
        }
        // Else if we have a friend with this name
        else
        {
            if (this.orderDictionary.Remove(id -1))
            {
                Console.Clear();
                Console.WriteLine("Order " + id + " has been removed successfully." + '\n' + "Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Unable to remove order number: " + id);
            } // end if
        } // end if
    } // end public bool RemoveFriend(string name)

    public void PrintMyOrders(int customerId)
    {
        Console.WriteLine("\t\t----------All Orders----------");
        foreach(Order order in this.orderDictionary.Values)
            {
                if(order.CustomerId == customerId)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t----------RECEIPT----------");
                    Console.WriteLine("\n" + "\tReceipt ID: " + order.Id);
                    Console.WriteLine("\tCustomer Id: " + order.CustomerId);
                    Console.WriteLine("\tDate ordered: " + order.DateNow + "\n");
                    Console.WriteLine("\tProducts Ordered: \n");
                    foreach (char prodId in order.Prods)
                    {
                        if(prodId == ',')
                        {
                            continue;
                        }
                        else 
                        {
                            // possibly code logic to show items and quanity oredered
                            //instead of printing all orders may have to change on the customer menu side 

                            ProductInformation pi = ProductInformation.Instance();
                            pi.Load();
                            int valId = int.Parse(prodId.ToString());
                            string name = pi.getName(valId);
                            Console.WriteLine("\t\tId: " + prodId + "\n\t\tName: " + name +"\n");
                        }
                    }
                }
            }
    }

    public int ProdCount()
    {
        return this.orderDictionary.Count;
    }

    public bool checkValidId(int id)
    {
        foreach (Order order in this.orderDictionary.Values)
        {
            if(order.Id == id) return true;
        }
        return false;
    }

    public void PrintById(int id)
    {
        int check = 0;
         foreach(Order order in this.orderDictionary.Values)
        {   
            //if the order id matches the last item in the filtered list of the customers orders id
            //then that is considered the last order that was made because the order ids are in ascending order
            if(order.Id == id)
            {
                 // bug -- checks if id is the last order id but the latest may
                // have been placed by another custimer, so maybe
                // check if customerId is equal then within do a count 
                // of how many receipts are owned by this customer
                // and show the last receipt in that list
                // if(order.Id == lastOrder.Id)
                // {
                    Console.WriteLine("\n\t\t----------ORDER TO DELETE----------");
                    Console.WriteLine("\n" + "\tReceipt ID: " + order.Id);
                    Console.WriteLine("\tCustomer Id: " + order.CustomerId);
                    Console.WriteLine("\tDate ordered: " + order.DateNow + "\n");
                    Console.WriteLine("\tProducts Ordered: \n");
                    foreach (char prodId in order.Prods)
                    {
                        if(prodId == ',')
                        {
                            continue;
                        }
                        else 
                        {
                            // possibly code logic to show items and quanity oredered
                            //instead of printing all orders may have to change on the customer menu side 
                            ProductInformation pi = ProductInformation.Instance();
                            pi.Load();
                            int valId = int.Parse(prodId.ToString());
                            string name = pi.getName(valId);
                            Console.WriteLine("\t\tId: " + prodId + "\n\t\tName: " + name +"\n");
                            check++;
                        }
                     }
                }
        }
    }

    public void PrintLatest(int custId)
    {
        int check = 0;
        //saves the orders that match the customer id into the list 
        var filtered = new List<Order>();

        foreach(Order order in this.orderDictionary.Values)
        {
            if(order.CustomerId == custId)
            {
                filtered.Add(order);
            }
        }

         foreach(Order order in this.orderDictionary.Values)
        {   
            //if the order id matches the last item in the filtered list of the customers orders id
            //then that is considered the last order that was made because the order ids are in ascending order
            if(order.Id == filtered[filtered.Count - 1].Id)
            {
                 // bug -- checks if id is the last order id but the latest may
                // have been placed by another custimer, so maybe
                // check if customerId is equal then within do a count 
                // of how many receipts are owned by this customer
                // and show the last receipt in that list
                // if(order.Id == lastOrder.Id)
                // {
                    Console.WriteLine("\n\t\t----------LATEST ORDER RECEIPT----------");
                    Console.WriteLine("\t\nReceipt ID: " + order.Id);
                    Console.WriteLine("\tCustomer Id: " + order.CustomerId);
                    Console.WriteLine("\tDate ordered: " + order.DateNow + "\n");
                    Console.WriteLine("\tProducts Ordered: \n");
                    int count = 0;
                    foreach (char prodId in order.Prods)
                    {
                        if(prodId == ',')
                        {
                            continue;
                        }
                        else 
                        {
                            // possibly code logic to show items and quanity oredered
                            //instead of printing all orders may have to change on the customer menu side 
                            ProductInformation pi = ProductInformation.Instance();
                            pi.Load();
                            int valId = int.Parse(prodId.ToString());
                            string name = pi.getName(valId);
                            Console.WriteLine("\t\tAmount ordered: "  + order.ProductAmount[count++].ToString() + "\nId: " + prodId + "\n\t\tName: " + name +"\n");
                            check++;
                        }
                     }
                     foreach (char prodId in order.Prods)
                    {
                        if(prodId == ',')
                        {
                            continue;
                        }
                        else 
                        {
                            // possibly code logic to show items and quanity oredered
                            //instead of printing all orders may have to change on the customer menu side 
                            ProductInformation pi = ProductInformation.Instance();
                            pi.Load();
                            int valId = int.Parse(prodId.ToString());
                            string name = pi.getName(valId);
                            Console.WriteLine("\t\tAmount ordered: "  + order.ProductAmount[count++].ToString() + "\nId: " + prodId + "\n\t\tName: " + name +"\n");
                            check++;
                        }
                     }
                }
        }
                  // if(check == 0) Console.WriteLine("Error No Orders");
    }
 
    public void Save()
    {
        // Gain code access to the file that we are going
        // to write to
        try
        {
            // Create a FileStream that will write data to file.
            FileStream writerFileStream = 
                new FileStream(DATA_FILENAME, FileMode.Create, FileAccess.Write);
            // Save our dictionary of friends to file
            this.formatter.Serialize(writerFileStream, this.orderDictionary);
 
            // Close the writerFileStream when we are done.
            writerFileStream.Close();
        }
        catch (Exception) {
            Console.WriteLine("Unable to save order information");
        } // end try-catch
    } // end public bool Load()
              
    public void Load() 
    {
      
        // Check if we had previously Save information of our friends
        // previously
        if (File.Exists(DATA_FILENAME))
        {
 
            try
            {
                // Create a FileStream will gain read access to the 
                // data file.
                FileStream readerFileStream = new FileStream(DATA_FILENAME, 
                    FileMode.Open, FileAccess.Read);
                // Reconstruct information of our friends from file.
                this.orderDictionary = (Dictionary<int, Order>)
                    this.formatter.Deserialize(readerFileStream);
                // Close the readerFileStream when we are done
                readerFileStream.Close();
 
            } 
            catch (Exception)
            {
                Console.WriteLine("There seems to be a file that contains " +
                    "order information but somehow there is a problem " +
                    "with reading it.");
            } // end try-catch
 
        } // end if
         
    } // end public bool Load()
 
    public void Print()
    {
        // If we have saved information about friends
        try
        {
            if (this.orderDictionary.Count > 0)
        {
            foreach (Order order in this.orderDictionary.Values)
            {
                Console.WriteLine("\n\t\t----------RECEIPT----------");
                Console.WriteLine("\n" + "\tReceipt ID: " + order.Id);
                Console.WriteLine("\tCustomer Id: " + order.CustomerId);
                Console.WriteLine("\tDate ordered: " + order.DateNow + "\n");
                Console.WriteLine("\tProducts Ordered: \n");
                foreach (char prodId in order.Prods)
                {
                    if(prodId == ',')
                    {
                        continue;
                    }
                    else 
                    {
                        // possibly code logic to show items and quanity oredered
                        //instead of printing all orders may have to change on the customer menu side 

                        ProductInformation pi = ProductInformation.Instance();
                        pi.Load();
                        int valId = int.Parse(prodId.ToString());
                        string name = pi.getName(valId);
                        Console.WriteLine("\t\t" + "Id: " + prodId + "\n\t\tName: " + name +"\n");
                    }
                }

                foreach (char amnts in order.Amounts)
                    {
                        if(amnts == ',')
                        {
                            continue;
                        }
                        else 
                        {
                            // possibly code logic to show items and quanity oredered
                            //instead of printing all orders may have to change on the customer menu side 
                            Console.WriteLine("\t\t\nId: " + amnts +"\n");
                        }
                     }
            } // end foreach
        }
        else
        {
            Console.WriteLine("There are no saved information about your orders");
        } 
        }
        catch (System.Exception)
        {
            Console.WriteLine("error here");
            throw;
        }// end if
    } // end public void Print()

    
 
} // end public class FriendsInformation