using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi;

public class Product
{
     #region Fields
     
     public string Name { get; set; }
     public int UPC { get; set; }
     private Dictionary<PriceState, decimal> Prices { get; set; }
     
     #endregion
     #region Getter&Setter
     
     public decimal Price(PriceState state) => Prices[state];
     public void Price(PriceState state, decimal price) => Prices[state] = price.ValidatePrice();  
     
     #endregion
     #region Constructors
     
     public Product()
     {
          Name = "Product-Unknown";
          UPC = 0;
          Prices = new Dictionary<PriceState, decimal>(); 
          Price(PriceState.Normal, 1);
     }
     public Product(string name, int upc, Dictionary<PriceState, decimal> prices)
     {
          Name = name;
          UPC = upc;
          Prices = prices;
     }
     
     #endregion
     #region GeneralMethods
     public void PrintInfo()
     {
          Console.WriteLine($"Name: {0} UPC: {1} Original Price: {2}, Taxed Price: {3} Net: {4}",Name,UPC,Prices[PriceState.Normal],Prices[PriceState.Taxed]);
     }
     #endregion     
}