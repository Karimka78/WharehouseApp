using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Represents an injectable medicine type.
    // Inherits all stock management behavior from Medicine.
    public class Injection : Medicine
    {
        // Creates a new Injection with the given code, name, quantity, and price.
        public Injection(string code, string name, int quantity, double price)
            : base(code, name, quantity, price) { }

        // Returns a formatted string identifying this item as an Injection
        // along with its name, current quantity, and unit price.
        public override string GetInfo()
        {
            return $"Injection -> {Name}, Qty: {Quantity}, Price: {Price}";
        }
    }
}
