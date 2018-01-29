using System;
using Newtonsoft.Json;

namespace Lab1
{
    class Program
    {
        // Creates the Products
        static Product[] CreateProducts()
        {
            return new Product[3]
            {
                new Product 
                {
                    ID = 0,
                    Name = "Product1",
                    Price = 10.99
                },
                new Product
                {
                    ID = 1,
                    Name = "Product2",
                    Price = 20.99
                },
                new Product
                {
                    ID = 2,
                    Name = "Product3",
                    Price = 30.99
                }
            };
        }
        
        static void Main(string[] args)
        {
            // Create JSON and print (Serialization)
            var jsonString = JsonConvert.SerializeObject(CreateProducts());
            
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(jsonString);
            Console.WriteLine("++++++++++++++++++");
            
            // Restore Objects and print (Deserialization)
            var products = JsonConvert.DeserializeObject<Product[]>(jsonString);
            foreach (var product in products)
            {
                Console.WriteLine($@"{product.ID + 1}, 
                                    {product.Name}, 
                                    Price: {product.Price}");
            }
        }
    }
}
