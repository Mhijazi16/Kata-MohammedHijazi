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
     
     public Product()
     {
          Info = new ProductInfo("Unkown-Product", -1);
          Tax = new Tax(Price(PriceState.Normal));
          Discount = new Discount(Price(PriceState.Normal),0);
          this.SetupPrices(1);
     }
     public Product(ProductInfo info,decimal taxRatio,decimal discountRatio, decimal price)
     {
          this.Info = info;
          this.Tax = new Tax(taxRatio);
          this.Discount = new Discount(price,discountRatio);
          this.SetupPrices(price);
     }
     public Product(ProductInfo info,decimal discountRatio, decimal price)
     {
           this.Info = info;
           this.Tax = new Tax(price,0.2m);
           this.Discount = new Discount(price, discountRatio);
           this.SetupPrices(price);
     }
     public Product(ProductInfo info, Tax tax, Discount discount)
     {
          Info = info;
          Tax = tax;
          Discount = discount;
     }

     #endregion
       
}