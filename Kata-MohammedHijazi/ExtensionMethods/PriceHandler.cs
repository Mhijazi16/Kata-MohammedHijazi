using System.Runtime.CompilerServices;
using Kata_MohammedHijazi.Transactions;

namespace Kata_MohammedHijazi.ExtensionMethods;

public static class PriceHandler
{

   #region SettingUpPrices 
   public static void InitializePrices(this Product prod, decimal price)
    {
       prod.Price(PriceState.Normal, price);
       prod.Price(PriceState.Taxed, 0);
       prod.Price(PriceState.Discounted, 0);
       prod.Price(PriceState.Net, 0); 
    }
 
    public static void SetupPricesWithPrecedence(this Product prod,decimal price)
    {
        prod.Discount.selectiveDiscount.Amount = price;
        prod.Tax.Amount = prod.Discount.selectiveDiscount.ApplySelective(price);
        prod.Discount.Amount = prod.Discount.selectiveDiscount.ApplySelective(price); 
        
        
        prod.Price(PriceState.Normal, price);
        prod.Price(PriceState.Taxed, prod.Tax.ApplyTax(price));
        prod.Price(PriceState.Discounted, prod.Discount.ApplyDiscount(price));
        prod.Price(PriceState.Selective, prod.Discount.selectiveDiscount.ApplySelective(price));    
        prod.Price(PriceState.Net, price - prod.Discount.selectiveDiscount.Amount + prod.Tax.Amount - prod.Discount.Amount);
    }
     public static void SetupPrices(this Product prod,decimal price)
     {
         decimal Taxed = prod.Tax.ApplyTax(price);
         decimal Discounted = prod.Discount.ApplyDiscount(Taxed);
         decimal Selective = prod.Discount.selectiveDiscount.ApplySelective(Discounted);
         decimal Net = Selective.ReturnNotZero(Discounted, Taxed);  
         prod.Price(PriceState.Normal, price);
         prod.Price(PriceState.Taxed, Taxed);
         prod.Price(PriceState.Discounted, Discounted);
         prod.Price(PriceState.Selective, Selective);    
         prod.Price(PriceState.Net, Net);
     }   
    
   #endregion
  
}