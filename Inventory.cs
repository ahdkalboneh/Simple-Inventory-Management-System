using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters;

public class Inventory
{
    public List<Product> Products { get; set; } = new List<Product>();

    public void AddProduct(Product Pr)
    {
        Products.Add(Pr);
    }

    public bool IsEmpty()
    {
        if(Products.Count == 0)
        {
            return true;
        }

        return false;
    }

    public void ShowInventory()
    {
        if (this.IsEmpty())
        {
        Console.WriteLine("Inventory is empty. Please add products to show.");
        return;
        }
        Console.WriteLine("Showing the inventory..");
        foreach (var product in Products)
        {
            Console.WriteLine("***************");
            Console.WriteLine("Product Name: " + product.Name+ "\nProduct Price: "+ product.Price+ "\nItems Available: " + product.Quantity);
        }

        Console.WriteLine("***************");
    } 
}