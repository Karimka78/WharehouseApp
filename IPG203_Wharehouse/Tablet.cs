using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Represents a tablet medicine type.
    // Inherits all stock management behavior from Medicine.
    public class Tablet : Medicine
    {
        // Creates a new Tablet with the given code, name, quantity, and price.
        public Tablet(string code, string name, int quantity, double price)
            : base(code, name, quantity, price) { }

        // Returns a formatted string identifying this item as a Tablet
        // along with its name, current quantity, and unit price.
        public override string GetInfo()
        {
            return $"Tablet -> {Name}, Qty: {Quantity}, Price: {Price}";
        }
    }
}
