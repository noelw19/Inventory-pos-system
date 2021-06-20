using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using B0Layer;
 
public class CustomerInformation
{
 
    private static CustomerInformation customerInformation;
 
    private Dictionary<string, Customer> customerDictionary;
    private BinaryFormatter formatter;
 
    private const string DATA_FILENAME = "customerinformation.dat";
 
    public static CustomerInformation Instance()
    {
        if (customerInformation == null) {
            customerInformation = new CustomerInformation();
        } // end if
 
        return customerInformation;
    } // end public static FriendsInformation Instance()
 
    private CustomerInformation()
    {
        // Create a Dictionary to store friends at runtime
        this.customerDictionary = new Dictionary<string, Customer>();
        this.formatter = new BinaryFormatter();
    } // end private FriendsInformation()
 
    public void AddFriend(string name, string username, string pin)
    {
        // If we already had added a friend with this name
        if (this.customerDictionary.ContainsKey(name) || this.customerDictionary.ContainsKey(username))
        {
            Console.WriteLine("You had already added " + name + " before.");
        }
        // Else if we do not have this friend details 
        // in our dictionary
        else
        {
            // Add him in the dictionary
            this.customerDictionary.Add(name, new Customer(name, username, pin));
            Console.WriteLine("Customer added successfully.");
        } // end if
    } // end public bool AddFriend(string name, string email)
 
    public void RemoveCustomer(string name)
    {
        // If we do not have a friend with this name
        if (!this.customerDictionary.ContainsKey(name))
        {
            Console.WriteLine(name + " had not been added before.");
        }
        // Else if we have a friend with this name
        else
        {
            if (this.customerDictionary.Remove(name))
            {
                Console.WriteLine(name + " had been removed successfully.");
            }
            else
            {
                Console.WriteLine("Unable to remove " + name);
            } // end if
        } // end if
    } // end public bool RemoveFriend(string name)
 
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
            this.formatter.Serialize(writerFileStream, this.customerDictionary);
 
            // Close the writerFileStream when we are done.
            writerFileStream.Close();
        }
        catch (Exception) {
            Console.WriteLine("Unable to save customers information");
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
                this.customerDictionary = (Dictionary<String, Customer>)
                    this.formatter.Deserialize(readerFileStream);
                // Close the readerFileStream when we are done
                readerFileStream.Close();
 
            } 
            catch (Exception)
            {
                Console.WriteLine("There seems to be a file that contains " +
                    "customer information but somehow there is a problem " +
                    "with reading it.");
            } // end try-catch
 
        } // end if
         
    } // end public bool Load()
 
    public void Print()
    {
        // If we have saved information about friends
        if (this.customerDictionary.Count > 0)
        {
            foreach (Customer customer in this.customerDictionary.Values)
            {
                Console.WriteLine("\n" + "Name: " + customer.Name);
                Console.WriteLine("Username: " + customer.Username);
                Console.WriteLine("Pin: " + customer.Pin + "\n");
            } // end foreach
        }
        else
        {
            Console.WriteLine("There are no saved information about your friends");
        } // end if
    } // end public void Print()

    public bool CheckCredentials(string username, string pin) 
    {
            foreach(Customer customer in this.customerDictionary.Values)
            {
                if(customer.Username == username && customer.Pin == pin)
                {
                    return true;
                }
            }
            return false;
        
    }
 
} // end public class FriendsInformation