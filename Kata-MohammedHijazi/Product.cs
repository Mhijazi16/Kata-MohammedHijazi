using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi;

public class Product
{
     public string Name { get; set; }
     public int UPC { get; set; }
     private Dictionary<PriceState, decimal> Prices { get; set; }
     public decimal Price(PriceState state) => Prices[state];
     public void Price(PriceState state, decimal price) => Prices[state] = price.ValidatePrice();  
     
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
}