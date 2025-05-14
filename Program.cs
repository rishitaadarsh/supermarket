// Basic Inventory Management System in C#
using System;
using System.Collections.Generic;

namespace InventoryManagement
{
    class Program
    {
        static List<Product> inventory = new List<Product>();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Update Quantity");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ViewInventory();
                        break;
                    case "3":
                        UpdateQuantity();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            inventory.Add(new Product { Name = name, Quantity = quantity });
            Console.WriteLine("Product added.");
        }

        static void ViewInventory()
        {
            Console.WriteLine("\nCurrent Inventory:");
            foreach (var item in inventory)
            {
                Console.WriteLine($"Product: {item.Name}, Quantity: {item.Quantity}");
            }
        }

        static void UpdateQuantity()
        {
            Console.Write("Enter product name to update: ");
            string name = Console.ReadLine();
            var product = inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                Console.Write("Enter new quantity: ");
                product.Quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Quantity updated.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
