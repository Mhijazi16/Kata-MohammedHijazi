using Kata_MohammedHijazi.ExtensionMethods;
using Kata_MohammedHijazi.Transactions;
using Kata_MohammedHijazi.Transactions.Discount;

namespace Kata_MohammedHijazi;

public class Product
{
     #region Fields

     public ProductInfo Info { get; set; } 
     public Tax Tax { get; set; }
     public Discount Discount { get; set; }
     public Dictionary<PriceState, decimal> Prices { get; set; } = new Dictionary<PriceState, decimal>();
     
     #endregion
     
     #region Getter&Setter
     
     public decimal Price(PriceState state) => Prices[state]; 
     public void Price(PriceState state, decimal price) => Prices[state] = price.ValidatePrice();  
    
     #endregion
     
     #region Constructors
     
     public Product(ProductInfo info, Tax tax, Discount discount, decimal price,ComputeState state)
     {
          Info = info;
          Tax = tax;
          Discount = discount;
          if (state == ComputeState.Additive)
               this.SetupAdditive();
          else if (state == ComputeState.Multiplicative) 
               this.SetupMultiplicative();
          else if (state == ComputeState.Precedence) ;
               this.SetupPrecedence();
     }
     
     #endregion
       
}