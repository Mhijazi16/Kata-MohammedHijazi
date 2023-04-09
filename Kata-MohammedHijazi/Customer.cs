using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi;

public class Customer
{
    public string Name { get; set; } 
    public List<Product> Products { get; set; }
    private decimal tax = 0.20m;
    public decimal Tax
    {
        get => tax;
        set => tax.ValidateTax(); 
    }

    public Customer()
    {
        Name = "Unkown-Customer";
        Tax = 0.20m;
        Products = new List<Product>();
    }

    public Customer(decimal tax, string name, List<Product> products)
    {
        this.tax = tax;
        Name = name;
        Products = products;
        Products.ApplyTaxToList(tax);
    }
}