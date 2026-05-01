using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Abstract base class representing a medicine item stored in the warehouse.
    // Implements IStorable to support stock management operations.
    public abstract class Medicine : IStorable
    {
        // Unique identifier for the medicine (e.g. "T001")
        private string code;

        // Display name of the medicine
        private string name;

        // Current stock quantity available in the warehouse
        private int quantity;

        // Unit price of the medicine
        private double price;

        // Gets the unique code of the medicine
        public string Code {
            get { return code; }
        }

        // Gets the name of the medicine
        public string Name {
            get { return name; }
        }

        // Gets or sets the current stock quantity.
        // The setter is protected so only subclasses can modify it directly.
        public int Quantity
        {
            get { return quantity; }
            protected set { quantity = value; }
        }

        // Gets the unit price of the medicine
        public double Price
        {
            get { return price; }
        }

        // Initializes a new medicine with the given details.
        // Invalid quantity or price values default to 0.
        // Also increments the global medicine counter.
        public Medicine(string code, string name, int quantity, double price)
        {
            this.code = code;
            this.name = name;
            this.quantity = Validator.IsValidQuantity(quantity) ? quantity : 0;
            this.price = Validator.IsValidPrice(price) ? price : 0;
            InventoryCounter.TotalMedicines++;
        }

        // Adds the specified quantity to the current stock.
        // Does nothing if the quantity is invalid (zero or negative).
        public void AddStock(int quantity)
        {
            if (Validator.IsValidQuantity(quantity))
                Quantity += quantity;
        }

        // Removes the specified quantity from the current stock.
        // Does nothing if the quantity is invalid or exceeds available stock.
        public void RemoveStock(int quantity)
        {
            if (Validator.IsValidQuantity(quantity) && quantity <= Quantity)
                Quantity -= quantity;
        }

        // Returns a formatted string with the medicine's details.
        // Each subclass provides its own implementation.
        public abstract string GetInfo();
    }
}
