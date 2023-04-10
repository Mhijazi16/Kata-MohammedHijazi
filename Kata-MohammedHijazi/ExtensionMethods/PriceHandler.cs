using System.Runtime.CompilerServices;

namespace Kata_MohammedHijazi.ExtensionMethods;

public static class PriceHandler
{
   #region HandlingTax&Discount 

    public static decimal ComputeAmount(this Product prod, decimal ratio) => ratio * prod.Price(PriceState.Normal);
    private static void ApplyTransaction(this Product product, decimal ratio, PriceState state)
    {
       decimal price = product.ComputeAmount(ratio) + product.Price(state);
       product.Price(state, price);
    }
    private static void ApplyAllTransactions(this Product product, decimal tax, decimal discount)
    {
       product.ApplyTransaction(tax,PriceState.Taxed);
       product.ApplyTransaction(discount,PriceState.Discounted);
       product.ComputeNetPrice();
    }
    
   #endregion
   #region NetPrice

    public static void ComputeNetPrice(this Product product)
    {
       decimal Net = product.Price(PriceState.Taxed) - product.Price(PriceState.Discounted);
       product.Price(PriceState.Net, Net);
    }

   #endregion
   #region SettingUpPrices 

   private static void InitializePrices(this Product prod, decimal price)
    {
       prod.Price(PriceState.Normal, price);
       prod.Price(PriceState.Taxed, 0);
       prod.Price(PriceState.Discounted, 0);
       prod.Price(PriceState.Net, 0); 
    }
    //For Setting Up The Prices
    public static void SetupPrices(this Product prod,decimal price, decimal tax, decimal discount )
    {
       prod.InitializePrices(price);
       prod.ApplyAllTransactions(tax,discount); 
    }

   #endregion
  
}