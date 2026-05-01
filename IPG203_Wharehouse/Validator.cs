using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Static helper class that provides input validation methods used across the project.
    public static class Validator
    {
        // Returns true if the quantity is greater than zero.
        public static bool IsValidQuantity(int quantity)
        {
            return quantity > 0;
        }

        // Returns true if the price is greater than zero.
        public static bool IsValidPrice(double price)
        {
            return price > 0;
        }

        // Returns true if the name is not null, empty, or whitespace.
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        // Returns true if the discount is between 0 and 100 inclusive.
        public static bool IsValidDiscount(double discount)
        {
            return discount >= 0 && discount <= 100;
        }
    }
}
