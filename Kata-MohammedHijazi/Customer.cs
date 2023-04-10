using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi;

public class Customer
{
    #region Fields

    public string Name { get; set; } 
    public List<Product> Products { get; set; }

    #endregion
    
    #region Constructors

     public Customer()
     {
         Name = "Unkown-Customer";
         Products = new List<Product>();
     }
     public Customer(string name, List<Product> products)
     {
         Name = name;
         Products = products;
     }

    #endregion

    public void PrintProducts()
    {
        foreach(Product item in Products)
            item.ReportProductInfo();
    } 
}