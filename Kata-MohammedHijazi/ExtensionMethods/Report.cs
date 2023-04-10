
namespace Kata_MohammedHijazi;

public static class Report
{
         public static void ReportProductInfo(this Product p)
         {
             decimal normal = p.Price(PriceState.Normal);
             decimal taxed = p.Price(PriceState.Taxed);
             decimal discounted = p.Price(PriceState.Discounted);
             decimal net = p.Price(PriceState.Net);
             
              Console.WriteLine("==============================================");
              Console.WriteLine($"Name: {p.Info.Name} , UPC: {p.Info.UPC} , Price: {normal}");
              Console.WriteLine($"Tax Amount: {p.Tax.Amount}, Discount Amount: {p.Discount.Amount},");
              Console.WriteLine($"Price Before Tax = {normal}, After Tax : {taxed}");
              Console.WriteLine($"After Discount : {discounted}, Net: {net}"); 
              Console.WriteLine("==============================================");
         }

         public static void ReportDiscount(this Product Prod)
         {
             string replace = Prod.Discount.isApplied ? Prod.Discount.Amount + "" : "No Discount is Applied"; 
             
             Console.WriteLine("===============================================");
             Console.WriteLine($"Tax Amount: {Prod.Tax.Amount}, Discount Amount: {replace}");
             Console.WriteLine($"Original Price: {Prod.Price(PriceState.Normal)}");
             Console.WriteLine($"Final Net Price: {Prod.Price(PriceState.Net)}");
             Console.WriteLine("===============================================");
         }
            
}