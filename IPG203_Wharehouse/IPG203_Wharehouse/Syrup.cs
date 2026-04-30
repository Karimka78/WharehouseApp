using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    public class Syrup : Medicine
    {
        public Syrup(string code, string name, int quantity, double price)
            : base(code, name, quantity, price) { }

        public override string GetInfo()
        {
            return $"Syrup -> {Name}, Qty: {Quantity}, Price: {Price}";
        }
    }
}
