using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Represents a purchase order placed by a pharmacy.
    // Holds the list of ordered items and calculates the total cost.
    public class Order
    {
        // The pharmacy that placed this order.
        public Pharmacy Pharmacy { get; set; }

        // The list of items included in this order.
        public List<OrderItem> Items { get; set; }

        // Calculates the total cost of the order by summing all item prices.
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

        // Initializes a new order for the given pharmacy with an empty item list.
        public Order(Pharmacy pharmacy)
        {
            Pharmacy = pharmacy;
            Items = new List<OrderItem>();
        }

        // Adds an item to the order.
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
    }
}
