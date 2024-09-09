// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var products = new List<Product>
{
    new Product { Name = "Laptop", Price = 1000, Brand = "Dell", Category = "Electronics", Description = "Dell Laptop" },
    new Product { Name = "Mobile", Price = 500, Brand = "Samsung", Category = "Electronics", Description = "Samsung Mobile" },
    new Product { Name = "Shirt", Price = 50, Brand = "Levis", Category = "Clothing", Description = "Levis Shirt" },
    new Product { Name = "T-Shirt", Price = 20, Brand = "Nike", Category = "Clothing", Description = "Nike T-Shirt" },
    new Product { Name = "Shoes", Price = 100, Brand = "Adidas", Category = "Footwear", Description = "Adidas Shoes" },
    new Product { Name = "Sneakers", Price = 80, Brand = "Reebok", Category = "Footwear", Description = "Reebok Sneakers" }
};


var productQuery = 
    from prod in products
    select  new {prod.Description, prod.Price};

foreach (var v in productQuery)
{
    Console.WriteLine("Cost of {0} is {1}", v.Description, v.Price);
    
}


public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
}