using System;
using System.Collections.Generic;
using System.Text;

namespace B0Layer
{
    [Serializable]
    public class Product
    {
        private int id = 0;
        private string name;
        private string type;
        private string supplier;
        private int quantityInStock;

        public Product(int id, string name, string type, string supplier, int quantityInStock)
        {
            this.id = id + 1;
            this.name = name;
            this.type = type;
            this.supplier = supplier;
            this.quantityInStock = quantityInStock;
        }

        public int Id
        {
            get { return this.id;}
            set {this.id = value;}
        }
        public string Name
        {
            get {return this.name;}
            set {this.name = value;}
        }
        public string Type
        {
            get {return this.type;}
            set {if (value == "Food" || value == "Drink") this.type = value;}
        }
        public string Supplier
        {
            get {return this.supplier;}
            set {this.supplier = value;}
        }
        public int Stock
        {
            get {return this.quantityInStock;}
            set {this.quantityInStock = value;}
        }
    }
}