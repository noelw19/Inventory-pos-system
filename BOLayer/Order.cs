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

        private int[] productAmount;
        private string prods = "";

        private string orderAmount = "";
        private DateTime dateNow;

        public Order(int id, int customerId, int[] productId, int[] productAmount, DateTime date)
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

            foreach (var item in productAmount)
            {
                if(item != 0)
                {
                    string comma = ""; 
                    if(productAmount[count + 1] != 0) comma = ",";
                    this.orderAmount += item.ToString() + comma;
                    count++;
                    Console.WriteLine("{0}", this.orderAmount);
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

        public string Amounts { get
        {
            return this.orderAmount;
        }}

        public int[] ProductIds { get
        {
            return this.productId;
        } set
        {
            this.productId = value;
        }}

        public int[] ProductAmount { get
        {
            return this.productAmount;
        } set
        {
            this.productAmount = value;
        }}

        public DateTime DateNow { get
        {
            return this.dateNow;
        }}
    }
}