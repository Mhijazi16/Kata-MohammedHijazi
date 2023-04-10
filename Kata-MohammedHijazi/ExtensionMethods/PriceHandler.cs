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
 
    public static void SetupPrices(this Product prod,decimal price)
    {
        decimal Taxed = prod.Tax.ApplyTax(price);
        decimal Discounted = prod.Discount.ApplyDiscount(Taxed); 
        
        prod.Price(PriceState.Normal, price);
        prod.Price(PriceState.Taxed, Taxed);
        prod.Price(PriceState.Discounted, Discounted);
        prod.Price(PriceState.Net, Discounted);

    }

   #endregion
  
}