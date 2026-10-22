using System.Net.Http.Headers;

public class Inventory
{
    public List<Product> Products { get; set; } = new List<Product>();

    public void AddProduct(Product Pr)
    {
        Products.Add(Pr);
    }
}