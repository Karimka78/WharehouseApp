using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Delegate type for the low-stock warning event.
    // Carries the pharmacy name, medicine name, and remaining quantity.
    public delegate void LowStockHandler(string pharmacyName, string medicineName, int quantity);

    // Central warehouse that manages medicine inventory and pharmacy orders.
    // Fires a LowStockWarning event whenever stock runs out or drops below the threshold.
    public class Warehouse
    {
        // Event raised when a medicine is out of stock or falls below the minimum level.
        public event LowStockHandler LowStockWarning;

        // Internal list of all medicines stored in the warehouse.
        private List<Medicine> medicines = new List<Medicine>();

        // Internal list of all confirmed orders processed by the warehouse.
        private List<Order> orders = new List<Order>();

        // Adds a medicine to the warehouse inventory.
        public void AddMedicine(Medicine med)
        {
            medicines.Add(med);
        }

        // Processes an incoming order from a pharmacy.
        // Validates stock availability for each item, fires warnings for low/out-of-stock medicines,
        // adjusts quantities to what is available, and saves the valid portion of the order.
        public void AddOrder(Order order)
        {
            Order validOrder = new Order(order.Pharmacy);

            foreach (OrderItem item in order.Items)
            {
                // Skip items that are completely out of stock and fire a warning.
                if (item.Medicine.Quantity == 0)
                {
                    LowStockWarning?.Invoke(
                        order.Pharmacy.PharmacyName,
                        item.Medicine.Name,
                        0
                    );
                    continue;
                }

                // If requested quantity exceeds available stock, fulfill only what is available.
                if (item.Quantity > item.Medicine.Quantity)
                {
                    LowStockWarning?.Invoke(
                        order.Pharmacy.PharmacyName,
                        item.Medicine.Name,
                        item.Medicine.Quantity
                    );

                    int available = item.Medicine.Quantity;

                    if (available > 0)
                    {
                        validOrder.AddItem(new OrderItem(item.Medicine, available));
                        item.Medicine.RemoveStock(available);
                    }
                }
                else
                {
                    validOrder.AddItem(item);
                    item.Medicine.RemoveStock(item.Quantity);
                }

                // Fire a warning if stock drops below the minimum threshold after fulfillment.
                if (item.Medicine.Quantity < 10)
                {
                    LowStockWarning?.Invoke(
                        order.Pharmacy.PharmacyName,
                        item.Medicine.Name,
                        item.Medicine.Quantity
                    );
                }
            }

            // Only save the order if at least one item was fulfilled.
            if (validOrder.Items.Count > 0)
            {
                orders.Add(validOrder);
                order.Pharmacy.AddToAccount(validOrder.TotalAmount);
                Console.WriteLine("Order saved successfully.");
            }
        }

        // Prints all orders placed by a specific pharmacy, including item details and totals.
        public void ShowOrdersByPharmacy(string pharmacyName)
        {
            bool found = false;

            foreach (Order order in orders)
            {
                if (order.Pharmacy.PharmacyName.ToLower() == pharmacyName.ToLower())
                {
                    found = true;

                    Console.WriteLine($"\nPharmacy: {order.Pharmacy.PharmacyName}");
                    Console.WriteLine($"Location: {order.Pharmacy.Location}");

                    foreach (OrderItem item in order.Items)
                    {
                        Console.WriteLine(
                            $"{item.Medicine.Name}: {item.MedicinePrice} * {item.Quantity} = {item.TotalPrice}"
                        );
                    }

                    Console.WriteLine($"Order Total: {order.TotalAmount}");
                }
            }

            if (!found)
            {
                Console.WriteLine("No orders found for this pharmacy.");
            }
        }

        // Prints all orders in the warehouse, grouped by pharmacy.
        public void ShowOrders()
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"\nPharmacy: {order.Pharmacy.PharmacyName}");

                foreach (OrderItem item in order.Items)
                {
                    Console.WriteLine($"{item.Medicine.Name}: {item.MedicinePrice} * {item.Quantity} = {item.TotalPrice}");
                }

                Console.WriteLine($"Total = {order.TotalAmount}");
            }
        }

        // Prints the current stock info for every medicine in the warehouse.
        public void ShowAllMedicines()
        {
            foreach (Medicine med in medicines)
            {
                Console.WriteLine(med.GetInfo());
            }
        }
    }
}
