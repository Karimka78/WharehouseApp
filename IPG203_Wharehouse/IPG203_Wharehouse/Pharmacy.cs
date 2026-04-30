using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    public class Pharmacy
    {
        public string PharmacyName { get; set; }
        public string Location { get; set; }
        public double TotalAccount { get; private set; }
        public double Discount { get; set; }

        public Pharmacy(string name, string location, double discount)
        {
            if (!Validator.IsValidName(name))
                PharmacyName = "Unknown";
            else
                PharmacyName = name;

            if (!Validator.IsValidName(location))
                Location = "Unknown";
            else
                Location = location;

            if (!Validator.IsValidDiscount(discount))
                Discount = 0;
            else
                Discount = discount;

            TotalAccount = 0;
        }

        public void AddToAccount(double amount)
        {
            double finalAmount = amount - (amount * Discount / 100);
            TotalAccount += finalAmount;
        }
    }
}
