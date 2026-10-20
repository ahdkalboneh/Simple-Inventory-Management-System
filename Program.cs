public class Program
{
    public static void Main(string[] args)
    {
       Console.WriteLine("Welcome to the Inventory Management System.. ");

       int Choice;
       Inventory inventory = new Inventory();

       do {
       Console.WriteLine("-------------------------");  
       Console.WriteLine("Please select an option:");   
       Console.WriteLine("1. Add a product.");
       Console.WriteLine("2. View all products.");
       Console.WriteLine("3. Update a product.");
       Console.WriteLine("4. Delete a product.");
       Console.WriteLine("5. Exit.");
       Console.WriteLine("-------------------------");  

       if (!int.TryParse(Console.ReadLine(), out Choice))
       {
        Console.WriteLine("❌ Invalid input. Please enter a number.");
        Choice = 0;
       }

       switch (Choice)
       {
            case 1:
            Product Pr = new Product();
            Console.WriteLine("Enter product name:");
            Pr.Name = Console.ReadLine() ?? "unkown";
            float Price;
            while (true) {
            Console.WriteLine("Enter product price:");
            if (float.TryParse(Console.ReadLine(), out Price) && Price > 0)
            {
                break;
            }
            Console.WriteLine("❌ Invalid price, Enter a valid number greater than 0.");
            }
            Pr.Price = Price;

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

            inventory.AddProduct(Pr);
            Console.WriteLine("✅ The Product added to the inventory successfully.");
            break;

            case 2:
            inventory.ShowInventory();
            break;

            case 3:
            if (inventory.IsEmpty())
            {
                Console.WriteLine("Inventory is empty.");
                break;
            }
            
            string? ProductName;
            while (true)
            {
            Console.WriteLine("Please enter the name of the product:");
            ProductName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ProductName))
            {
                break;
            }
            Console.WriteLine("Product name cannot be empty.");
            }
            if (inventory.IsExist(ProductName))
            {
            inventory.UpdateProduct(ProductName);
            }
            else
            {
            Console.WriteLine("The product does not exist.");
            }
            break;

            case 5:
            Console.WriteLine("Closing the Inventory Management System, Bye.");
            break;

            default:
            Console.WriteLine("❌ Invalid choice. Please try again.");
            break;
        }      
        
       } while (Choice != 5);

    }
}