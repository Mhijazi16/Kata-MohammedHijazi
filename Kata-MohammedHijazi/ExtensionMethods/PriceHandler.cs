namespace Kata_MohammedHijazi.ExtensionMethods;

public static class PriceHandler
{
   //For Computing The Taxed Price
   public static decimal ComputeTaxAmount(this Product prod, decimal tax) => tax * prod.Price(PriceState.Normal);
   public static void ApplyTax(this Product product, decimal tax)
   {
      decimal Taxed = product.ComputeTaxAmount(tax) + product.Price(PriceState.Normal);
      product.Price(PriceState.Taxed, Taxed);
   } 
   public static void ApplyTaxToList(this List<Product> list, decimal tax)
   {
      foreach (var item in list)
         item.ApplyTax(tax); 
   }
   //For Computing the Net Price
   public static void ComputeNetPrice(this Product product)
   {
      decimal Taxed = product.Price(PriceState.Taxed);
      product.Price(PriceState.Net, Taxed);
   }
}