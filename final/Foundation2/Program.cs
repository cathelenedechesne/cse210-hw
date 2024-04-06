using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(new List<Product>(), customer1); // Initialize order with an empty list
        order1.AddProduct(new Product("Widget", 123, 10.50f, 2)); // Assuming 123 is a suitable integer ID
        order1.AddProduct(new Product("Gadget", 456, 20.25f, 1)); // Assuming 456 is a suitable integer ID



        Address address2 = new Address("456 Oak St", "Sometown", "CA", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(new List<Product>(), customer2); // Initialize order with an empty list
        order2.AddProduct(new Product("Bobybob", 656, 5.75f, 6)); // Assuming 789 is a suitable integer ID
        order2.AddProduct(new Product("Thingything", 797, 3.95f, 8)); // Assuming 789 is a suitable integer ID
        order2.AddProduct(new Product("Truchmachinchouette", 446, 25.79f, 1)); // Assuming 789 is a suitable integer ID

        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}"); // Corrected method name

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}"); // Corrected method name
    }
}
