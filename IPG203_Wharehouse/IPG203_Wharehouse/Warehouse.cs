using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Wharehouse
{
    public delegate void LowStockHandler(string pharmacyName, string medicineName, int quantity);

    public class Warehouse
    {
        public event LowStockHandler LowStockWarning;

        private List<Medicine> medicines = new List<Medicine>();
        private List<Order> orders = new List<Order>();

        public void AddMedicine(Medicine med)
        {
            medicines.Add(med);
        }

        public void AddOrder(Order order)
        {
            Order validOrder = new Order(order.Pharmacy);

            foreach (OrderItem item in order.Items)
            {
                if (item.Medicine.Quantity == 0)
                {
                    LowStockWarning?.Invoke(
                        order.Pharmacy.PharmacyName,
                        item.Medicine.Name,
                        0
                    );
                    continue;
                }

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

                if (item.Medicine.Quantity < 10)
                {
                    LowStockWarning?.Invoke(
                        order.Pharmacy.PharmacyName,
                        item.Medicine.Name,
                        item.Medicine.Quantity
                    );
                }
            }

            if (validOrder.Items.Count > 0)
            {
                orders.Add(validOrder);
                order.Pharmacy.AddToAccount(validOrder.TotalAmount);
                Console.WriteLine("Order saved successfully.");
            }
        }

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

        public void ShowAllMedicines()
        {
            foreach (Medicine med in medicines)
            {
                Console.WriteLine(med.GetInfo());
            }
        }
    }
}
