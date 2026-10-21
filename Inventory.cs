using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters;

public class Inventory
{
    public List<Product> Products { get; set; } = new List<Product>();

    public void AddProduct(Product Pr)
    {
        Products.Add(Pr);
    }

    public void UpdateProduct(string ProductName)
    {
        if (this.IsEmpty())
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Product? Pr = Products.Find(P => P.Name == ProductName);
        if (Pr == null)
        {
        Console.WriteLine("Product not found.");
        return;
        }

        string? Name; 
        while (true)
        {
            Console.WriteLine("Enter new name:");
            Name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(Name))
            {
                break;
            }
            Console.WriteLine("Name cannot be empty.");
        }

        Pr.Name = Name;
            
        Console.WriteLine("Enter new price: ");
        float Price;
        while (true) {
            if (float.TryParse(Console.ReadLine(), out Price) && Price > 0)
            {
                break;
            }
        Console.WriteLine("❌ Invalid price, Enter a valid number greater than 0.");
        }
        Pr.Price = Price;

        Console.WriteLine("Enter new quantity: ");
        int Quantity;
        while (true){
        Console.WriteLine("Enter product quantity:");
        if (int.TryParse(Console.ReadLine(), out Quantity) && Quantity >= 0)
        {
        break;
        }
        Console.WriteLine("❌ Invalid Quantity, Enter a valid number greater than or equal 0.");
        }
        Pr.Quantity = Quantity;

        Console.WriteLine("The Product Updated Successfully. ✅");

    }

    public void DeleteProduct(string ProductName)
    {
        if (this.IsEmpty())
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Product? Pr = Products.Find(P => P.Name == ProductName);
        if (Pr == null)
        {
        Console.WriteLine("Product not found.");
        return;
        }

        Products.Remove(Pr);
        Console.WriteLine("The Product Deleted Successfully. ✅");   
    }

    public void SearchProduct(string ProductName)
    {
        if (this.IsEmpty())
        {
          Console.WriteLine("Inventory is empty.");
          return;   
        }

        Product? Pr = Products.Find(P => P.Name == ProductName);
        if (Pr == null)
        {
        Console.WriteLine("Product not found.");
        return;
        }

        Console.WriteLine("Product Name:"+ Pr.Name+ "\nProduct Price:"+ Pr.Price+ "\nProduct Quantity:" +Pr.Quantity);

    }

    public bool IsEmpty()
    {
        if(Products.Count == 0)
        {
            return true;
        }

        return false;
    }

    public bool IsExist(string ProductName)
    {
        if (Products.Exists(p => p.Name == ProductName))
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