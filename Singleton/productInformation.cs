using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using B0Layer;
 
public class ProductInformation
{
 
    private static ProductInformation productInformation;
 
    private Dictionary<string, Product> productDictionary;
    private BinaryFormatter formatter;
 
    private const string DATA_FILENAME = "productinformation.dat";
 
    public static ProductInformation Instance()
    {
        if (productInformation == null) {
            productInformation = new ProductInformation();
        } // end if
 
        return productInformation;
    } // end public static FriendsInformation Instance()
 
    private ProductInformation()
    {
        // Create a Dictionary to store friends at runtime
        this.productDictionary = new Dictionary<string, Product>();
        this.formatter = new BinaryFormatter();
    } // end private FriendsInformation()
 
    public void AddProduct(int id, string name, string type, string supplier, int quantity)
    {
        // If we already had added a friend with this name
        if (this.productDictionary.ContainsKey(name))
        {
            Console.WriteLine("You had already added " + name + " before.");
        }
        // Else if we do not have this friend details 
        // in our dictionary
        else
        {
            // Add him in the dictionary
            this.productDictionary.Add(name, new Product(id, name, type, supplier, quantity));
            Console.WriteLine("Product added successfully.");
        } // end if
    } // end public bool AddFriend(string name, string email)

    public void updateStock(int id, int amountToRemove)
    {
        foreach (Product prod in this.productDictionary.Values)
        {
            if (prod.Id == id){
                prod.UpdateStock(amountToRemove);
            }
        }
    }
 
    public void RemoveProduct(string name)
    {
        // If we do not have a friend with this name
        if (!this.productDictionary.ContainsKey(name))
        {
            Console.WriteLine(name + " had not been added before.");
        }
        // Else if we have a friend with this name
        else
        {
            if (this.productDictionary.Remove(name))
            {
                Console.WriteLine(name + " had been removed successfully.");
            }
            else
            {
                Console.WriteLine("Unable to remove " + name);
            } // end if
        } // end if
    } // end public bool RemoveFriend(string name)

    public int getId(string name)
    {
        foreach(Product product in this.productDictionary.Values)
            {
                if(product.Name == name)
                {
                    return product.Id;
                }
            }
                return 000;
    }

    public string getName(int id)
    {
        foreach(Product product in this.productDictionary.Values)
            {
                if(product.Id == id)
                {
                    return product.Name;
                }
            }
                return "Id Error";
    }

    public int ProdCount()
    {
        return this.productDictionary.Count;
    }

    // public void updateProduct(string name)

 
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
            this.formatter.Serialize(writerFileStream, this.productDictionary);
 
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
                this.productDictionary = (Dictionary<String, Product>)
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
        if (this.productDictionary.Count > 0)
        {
            foreach (Product product in this.productDictionary.Values)
            {
                Console.WriteLine("\n\t\tId: " + product.Id);
                Console.WriteLine("\t\tName: " + product.Name);
                Console.WriteLine("\t\tSupplier: " + product.Supplier);
                Console.WriteLine("\t\tStock Level: " + product.Stock);
                Console.WriteLine("\t\tType: " + product.Type + "\n");
                Console.WriteLine("----------------------------------------------------------\n");
            } // end foreach
        }
        else
        {
            Console.WriteLine("There are no saved information about your products");
        } // end if
    } // end public void Print()


 
} // end public class FriendsInformation