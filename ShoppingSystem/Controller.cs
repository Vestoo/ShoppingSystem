using ShoppingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

public class Controller
{
    private List<Receipt> shop;
    private List<Product> currClient;

    public Controller()
    {
        shop = new List<Receipt>();
        currClient = new List<Product>();
    }
    public string ProcessProductCommand(List<string> args)
    {
        PhysicalProduct product = new PhysicalProduct(args[0], double.Parse(args[1]), double.Parse(args[2]));
        currClient.Add(product);
        return product.ToString();
    }
    public string ProcessServiceCommand(List<string> args)
    {
        ServiceProduct product = new ServiceProduct(args[0], double.Parse(args[1]), double.Parse(args[2]));
        currClient.Add(product);
        return product.ToString();
    }
    public string ProcessCheckoutCommand(List<string> args)
    {
        Receipt receipt = new Receipt(args[0]);
        foreach (var item in currClient)
        {
            receipt.AddProduct(item);
        }
        currClient.Clear();
        shop.Add(receipt);
        return receipt.ToString();
    }
    public string ProcessInfoCommand(List<string> args)
    {
        switch (args[0])
        {
            case "Customer":
                double sum = 0;
                foreach (var product in currClient)
                {
                    sum += product.Price;
                }
                Console.WriteLine($"Current customer products: {currClient.Count}");
                Console.WriteLine($"Total price: {sum}");
                break;
            case "Shop":
                foreach (var receipt in shop)
                {
                    receipt.ToString();
                }
                break;
            default:
                Console.WriteLine("Please choose between \"Info shop\" or \"Info customer\" ");
                break;
        }
        return null;
    }
    public string ProcessEndCommand()
    {
        return $"Total customers: {shop.Count}";
    }
}
