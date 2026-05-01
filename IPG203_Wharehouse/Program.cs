using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    // Entry point of the warehouse management application.
    class Program
    {
        static void Main(string[] args)
        {
            // Create the warehouse and subscribe to the low-stock warning event.
            Warehouse warehouse = new Warehouse();
            warehouse.LowStockWarning += ShowWarning;

            // Create sample medicines of each type.
            Medicine medicine1 = new Tablet("T001", "Cetamol", 50, 2.5);
            Medicine medicine2 = new Syrup("S001", "Vitamin C Syrup", 20, 5);
            Medicine medicine3 = new Injection("I001", "Calcium", 10, 8);

            // Add medicines to the warehouse inventory.
            warehouse.AddMedicine(medicine1);
            warehouse.AddMedicine(medicine2);
            warehouse.AddMedicine(medicine3);
            Console.WriteLine("\nAvaliable Medicines In the Wharehouse:");
            warehouse.ShowAllMedicines();
            Console.WriteLine("\n=============================================");

            // First pharmacy places an order for tablets and injections.
            Pharmacy pharmacy = new Pharmacy("First Pharmacy", "Damascus", 5);
            Order order = new Order(pharmacy);
            order.AddItem(new OrderItem(medicine1, 5));
            order.AddItem(new OrderItem(medicine3, 5));
            warehouse.AddOrder(order);

            Console.WriteLine("\nOrders for First Pharmacy:");
            warehouse.ShowOrdersByPharmacy("First Pharmacy");
            // -----------------------

            // Second pharmacy places a larger order covering all three medicine types.
            Pharmacy pharmacy2 = new Pharmacy("Second Pharmacy", "Damascus", 10);
            Order order2 = new Order(pharmacy2);
            order2.AddItem(new OrderItem(medicine1, 10));
            order2.AddItem(new OrderItem(medicine3, 5));
            order2.AddItem(new OrderItem(medicine2, 10));
            warehouse.AddOrder(order2);

            Console.WriteLine("\nOrders for Second Pharmacy:");
            warehouse.ShowOrdersByPharmacy("Second Pharmacy");
            // -----------------------

            // Third pharmacy places two separate orders for tablets and syrups.
            Pharmacy pharmacy3 = new Pharmacy("Third Pharmacy", "Aleppo", 5);

            Order order3 = new Order(pharmacy3);
            order3.AddItem(new OrderItem(medicine1, 10));
            order3.AddItem(new OrderItem(medicine2, 10));
            warehouse.AddOrder(order3);

            Order order4 = new Order(pharmacy3);
            order4.AddItem(new OrderItem(medicine1, 10));
            warehouse.AddOrder(order4);

            Console.WriteLine("\nOrders for Third Pharmacy:");
            warehouse.ShowOrdersByPharmacy("Third Pharmacy");
            //-------------------------------

            // Display a summary of all orders and the remaining stock.
            Console.WriteLine("\n=============================================");
            Console.WriteLine("\nAll orders:");
            warehouse.ShowOrders();
            Console.WriteLine("\n Remaining Medicines In the Wharehouse:");
            warehouse.ShowAllMedicines();
            Console.ReadLine();
        }

        // Event handler that prints a colored warning when a medicine is low or out of stock.
        static void ShowWarning(string pharmacyName, string medicineName, int quantity)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            if (quantity == 0)
            {
                Console.WriteLine(
                    $"{medicineName} is OUT OF STOCK - Requested by {pharmacyName}"
                );
            }
            else
            {
                Console.WriteLine(
                    $"{medicineName} is LOW IN STOCK ({quantity}) - Requested by {pharmacyName}"
                );
            }

            Console.ResetColor();
        }
    }
}
