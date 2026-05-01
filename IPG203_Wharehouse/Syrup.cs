using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Represents a syrup medicine type.
    // Inherits all stock management behavior from Medicine.
    public class Syrup : Medicine
    {
        // Creates a new Syrup with the given code, name, quantity, and price.
        public Syrup(string code, string name, int quantity, double price)
            : base(code, name, quantity, price) { }

        // Returns a formatted string identifying this item as a Syrup
        // along with its name, current quantity, and unit price.
        public override string GetInfo()
        {
            return $"Syrup -> {Name}, Qty: {Quantity}, Price: {Price}";
        }
    }
}
