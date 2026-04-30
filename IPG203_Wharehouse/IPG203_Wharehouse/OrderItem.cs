using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    public class OrderItem
    {
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }

        public double TotalPrice
        {
            get { return Medicine.Price* Quantity; }
        }

        public double MedicinePrice
        {
            get { return Medicine.Price; }
        }

        public OrderItem(Medicine medicine, int quantity)
        {
            Medicine = medicine;
            Quantity = quantity;
        }
    }
}
