using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using B0Layer;
 
public class AdminInformation
{
 
    private static AdminInformation adminInformation;
 
    private Dictionary<string, Admin> adminDictionary;
    private BinaryFormatter formatter;
 
    private const string DATA_FILENAME = "admininformation.dat";
 
    public static AdminInformation Instance()
    {
        if (adminInformation == null) {
            adminInformation = new AdminInformation();
        } // end if
 
        return adminInformation;
    } // end public static FriendsInformation Instance()
 
    private AdminInformation()
    {
        // Create a Dictionary to store friends at runtime
        this.adminDictionary = new Dictionary<string, Admin>();
        this.formatter = new BinaryFormatter();
    } // end private FriendsInformation()
 
    public void AddAdmin(string username, string pin)
    {
        // If we already had added a friend with this name
        if (this.adminDictionary.ContainsKey(username))
        {
            Console.WriteLine("You had already added " + username + " before.");
        }
        // Else if we do not have this friend details 
        // in our dictionary
        else
        {
            // Add him in the dictionary
            this.adminDictionary.Add(username, new Admin(username, pin));
            Console.WriteLine("Customer added successfully.");
        } // end if
    } // end public bool AddFriend(string name, string email)
 
    public void RemoveAdmin(string name)
    {
        // If we do not have a friend with this name
        if (!this.adminDictionary.ContainsKey(name))
        {
            Console.WriteLine(name + " had not been added before.");
        }
        // Else if we have a friend with this name
        else
        {
            Console.WriteLine("dictionary count: {0}", this.adminDictionary.Count);
            if(this.adminDictionary.Count > 1)
            {
                if (this.adminDictionary.Remove(name))
                {
                    Console.WriteLine(name + " had been removed successfully.");
                }
                else
                {
                    Console.WriteLine("Unable to remove " + name);
                } // end if
            } //count if statement end
            else 
            {
                Console.WriteLine("Error cannot delete last admin");
            }
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
            this.formatter.Serialize(writerFileStream, this.adminDictionary);
 
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
                this.adminDictionary = (Dictionary<String, Admin>)
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
        if (this.adminDictionary.Count > 0)
        {
            Console.WriteLine(this.adminDictionary.Values.Count);
            foreach (Admin admin in this.adminDictionary.Values)
            {
                Console.WriteLine("\n\tUsername: " + admin.Username);
                Console.WriteLine("\tPin: " + admin.Pin + "\n");
            } // end foreach
        }
        else
        {
            Console.WriteLine("There are no saved information about your friends");
        } // end if
    } // end public void Print()

    public bool CheckCredentials(string username, string pin) 
    {
            foreach(Admin admin in this.adminDictionary.Values)
            {
                if(admin.Username == username && admin.Pin == pin)
                {
                    return true;
                }
            }
            return false;
        
    }
 
} // end public class FriendsInformation