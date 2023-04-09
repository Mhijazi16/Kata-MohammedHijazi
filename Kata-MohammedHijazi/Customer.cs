using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi;

public class Customer
{
    #region Fields

    public string Name { get; set; } 
        public List<Product> Products { get; set; }
        private decimal tax = 0.20m;
        public decimal Tax
        {
            get => tax;
            set => tax.ValidateTax(); 
        }


    #endregion
    
    #region Constructors

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

    #endregion

    public void PrintProducts()
    {
        foreach(Product item in Products)
            item.PrintInfo();
    } 
}