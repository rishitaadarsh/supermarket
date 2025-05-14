// Simple Supermarket Management System in C#
using System;
using System.Collections.Generic;

namespace SupermarketManagement
{
    class Program
    {
        static List<Product> products = new List<Product>();
        static double totalSales = 0;

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nSupermarket Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. Make Sale");
                Console.WriteLine("4. View Total Sales");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ListProducts();
                        break;
                    case "3":
                        MakeSale();
                        break;
                    case "4":
                        Console.WriteLine($"Total Sales: ${totalSales}");
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("Product name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            products.Add(new Product { Name = name, Price = price, Quantity = quantity });
            Console.WriteLine("Product added.");
        }

        static void ListProducts()
        {
            Console.WriteLine("\nAvailable Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - ${product.Price} - Qty: {product.Quantity}");
            }
        }

        static void MakeSale()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            var product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                Console.Write("Enter quantity to sell: ");
                int qty = int.Parse(Console.ReadLine());
                if (product.Quantity >= qty)
                {
                    product.Quantity -= qty;
                    double saleAmount = qty * product.Price;
                    totalSales += saleAmount;
                    Console.WriteLine($"Sale successful. Total: ${saleAmount}");
                }
                else
                {
                    Console.WriteLine("Insufficient stock.");
                }
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
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}


