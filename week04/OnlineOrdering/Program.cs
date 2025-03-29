using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            
            Address address1 = new Address("1009 Main St", "huntington", "UTAH", "USA");
            Address address2 = new Address("280", "Lima", "Lima", "Peru");

            Customer customer1 = new Customer("Carlos Medina", address1);
            Customer customer2 = new Customer("Robert Walton", address2);

            Product product1 = new Product("Phone", 101, 1000, 2);
            Product product2 = new Product("Laptop", 102, 2500, 1);
            Product product3 = new Product("Headphone", 103, 40, 1);

           
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product2);
            order2.AddProduct(product3);

           
            Console.WriteLine(order1.GetPackagingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");

            Console.WriteLine("\n" + order2.GetPackagingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
        }
    }
