namespace Kata_MohammedHijazi.ExtensionMethods;

public static class PriceHandler
{
   public static void ApplyTax(this Product product, decimal tax) => product.Price(PriceState.Taxed, tax);
   public static void ApplyTaxToList(this List<Product> list, decimal tax)
   {
      foreach (var item in list)
         item.ApplyTax(tax); 
   }
}