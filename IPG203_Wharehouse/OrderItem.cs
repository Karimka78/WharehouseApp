using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Represents a single line item in an order, linking a medicine to a requested quantity.
    public class OrderItem
    {
        // The medicine being ordered.
        public Medicine Medicine { get; set; }

        // The number of units requested for this item.
        public int Quantity { get; set; }

        // Calculates the total price for this line item (unit price * quantity).
        public double TotalPrice
        {
            get { return Medicine.Price * Quantity; }
        }

        // Exposes the unit price of the medicine for display purposes.
        public double MedicinePrice
        {
            get { return Medicine.Price; }
        }

        // Initializes a new order item with the specified medicine and quantity.
        public OrderItem(Medicine medicine, int quantity)
        {
            Medicine = medicine;
            Quantity = quantity;
        }
    }
}
