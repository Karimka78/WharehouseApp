using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    public class Order
    {
        public Pharmacy Pharmacy { get; set; }
        public List<OrderItem> Items { get; set; }

        public double TotalAmount
        {
            get
            {
                double total = 0;
                foreach (OrderItem item in Items)
                    total += item.TotalPrice;
                return total;
            }
        }

        public Order(Pharmacy pharmacy)
        {
            Pharmacy = pharmacy;
            Items = new List<OrderItem>();
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
    }
}
