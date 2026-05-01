using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Represents a pharmacy that places orders with the warehouse.
    // Tracks the pharmacy's name, location, discount rate, and total spending.
    public class Pharmacy
    {
        // The display name of the pharmacy.
        public string PharmacyName { get; set; }

        // The city or address where the pharmacy is located.
        public string Location { get; set; }

        // The cumulative amount billed to this pharmacy after applying discounts.
        public double TotalAccount { get; private set; }

        // The discount percentage applied to every order (0–100).
        public double Discount { get; set; }

        // Initializes a pharmacy with a name, location, and discount.
        // Falls back to "Unknown" for invalid name/location and 0 for invalid discount.
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

        // Adds an order amount to the pharmacy's account after applying the discount.
        public void AddToAccount(double amount)
        {
            double finalAmount = amount - (amount * Discount / 100);
            TotalAccount += finalAmount;
        }
    }
}
