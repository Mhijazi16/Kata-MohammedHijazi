using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi;

public class Product
{
     #region Fields
     
     public string Name { get; set; }
     public int UPC { get; set; }
     private Dictionary<PriceState, decimal> Prices { get; set; }
     private decimal tax = 0.20m;
     
     #endregion
     #region Getter&Setter
     
     public decimal Price(PriceState state) => Prices[state];
     public void Price(PriceState state, decimal price) => Prices[state] = price.ValidatePrice();  
     public decimal Tax
                  {
                      get => tax;
                      set => tax.ValidateTax(); 
                  }
     #endregion
     #region Constructors
     
     public Product()
     {
          Name = "Product-Unknown";
          UPC = 0;
          Tax = 0.20m;
          Prices = new Dictionary<PriceState, decimal>(); 
          Price(PriceState.Normal, 1);
          this.ApplyTax(Tax);
          this.ComputeNetPrice();
     }
     public Product(string name, int upc,decimal tax, Dictionary<PriceState, decimal> prices)
     {
          Name = name;
          UPC = upc;
          Prices = prices;
          this.Tax = tax; 
          this.ApplyTax(tax);
          this.ComputeNetPrice();
     }
     
     #endregion
     #region GeneralMethods
     public void PrintInfo()
     {
          Console.WriteLine("==============================================");
          Console.WriteLine($"Name: {Name} , UPC: {UPC} , Price: {Prices[PriceState.Normal]}");
          Console.WriteLine($"Price Before Tax = {Prices[PriceState.Normal]}, and After Tax : {Prices[PriceState.Taxed]}");
          Console.WriteLine("==============================================");
     }
     #endregion     
}