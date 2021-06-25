using System;
using System.Collections.Generic;
using System.Text;

namespace B0Layer
{
    [Serializable]
    public class Order
    {
        private int orderId = 0;
        private int customerId;
        private int[] productId;
        private string prods = "";
        private DateTime dateNow;

        public Order(int id, int customerId, int[] productId, DateTime date)
        {
            this.customerId = customerId;
            int count = 0;
            foreach (var item in productId)
            {
                if(item != 0)
                {
                    string comma = ""; 
                    if(productId[count + 1] != 0) comma = ",";
                    this.prods += item.ToString() + comma;
                    count++;
                    Console.WriteLine("{0}", this.prods);
                }
            }
            this.dateNow = date;
            this.orderId = id + 1;
        }

        public int Id { get
        {
            return this.orderId;
        } set
        {
            this.orderId = value;
        }}

        public int CustomerId { get
        {
            return this.customerId;
        } set
        {
            this.customerId = value;
        }}

        public string Prods { get
        {
            return this.prods;
        }}

        public int[] ProductIds { get
        {
            return this.productId;
        } set
        {
            this.productId = value;
        }}

        public DateTime DateNow { get
        {
            return this.dateNow;
        }}
    }
}