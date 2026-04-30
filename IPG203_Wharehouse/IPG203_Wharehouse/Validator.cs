using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    public static class Validator
    {
        public static bool IsValidQuantity(int quantity)
        {
            return quantity > 0;
        }

        public static bool IsValidPrice(double price)
        {
            return price > 0;
        }

        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public static bool IsValidDiscount(double discount)
        {
            return discount >= 0 && discount <= 100;
        }
    }
}
