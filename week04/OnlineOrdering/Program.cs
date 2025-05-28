class Program
{
    static void Main()
    {
        Address address1 = new Address("AW-3567-5432", "Bibiani", "BN", "Ghana");
        Customer customer1 = new Customer("Locadia Kanyir", address1);

        Address address2 = new Address("AW-4020-0753", "Kumasi", "KS", "Ghana");
        Customer customer2 = new Customer("Sampson Havor", address2);

        Product product1 = new Product("Laptop", "A123", 999.99, 1);
        Product product2 = new Product("Mouse", "B456", 25.99, 2);
        Product product3 = new Product("Keyboard", "C789", 49.99, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}");
            Console.WriteLine();
        }
    }
}
