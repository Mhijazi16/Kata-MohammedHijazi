using Kata_MohammedHijazi.ExtensionMethods;
using Kata_MohammedHijazi.Transactions;

namespace Kata_MohammedHijazi;

public class Product
{
     #region Fields

     public ProductInfo Info { get; set; } 
     public Tax Tax { get; set; }
     public Discount Discount { get; set; }
     private Dictionary<PriceState, decimal> Prices = new Dictionary<PriceState, decimal>();  
     
     #endregion
     
     #region Getter&Setter
     
     public decimal Price(PriceState state) => Prices[state]; 
     public void Price(PriceState state, decimal price) => Prices[state] = price.ValidatePrice();  
    
     #endregion
     
     #region Constructors
     
     public Product(ProductInfo info, Tax tax, Discount discount, decimal price,bool activatePrecedence)
     {
          Info = info;
          Tax = tax;
          Discount = discount;
          if(activatePrecedence)
               this.SetupPricesWithPrecedence(price);
          else
               this.SetupPrices(price);
     }
     
     #endregion
       
}