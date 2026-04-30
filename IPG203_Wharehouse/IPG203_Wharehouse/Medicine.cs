using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    public abstract class Medicine : IStorable
    {
        private string code;
        private string name;
        private int quantity;
        private double price;

        public string Code {
            get { return code; }
        }
        public string Name {
            get { return name; }
        }
        public int Quantity
        {
            get { return quantity; }
            protected set { quantity = value; }
        }

        public double Price
        {
            get { return price; }
        }

        public Medicine(string code, string name, int quantity, double price)
        {
            this.code = code;
            this.name = name;
            this.quantity = Validator.IsValidQuantity(quantity) ? quantity : 0;
            this.price = Validator.IsValidPrice(price) ? price : 0;
            InventoryCounter.TotalMedicines++;
        }

        public void AddStock(int quantity)
        {
            if (Validator.IsValidQuantity(quantity))
                Quantity += quantity;
        }

        public void RemoveStock(int quantity)
        {
            if (Validator.IsValidQuantity(quantity) && quantity <= Quantity)
                Quantity -= quantity;
        }

        public abstract string GetInfo();
    }
}
