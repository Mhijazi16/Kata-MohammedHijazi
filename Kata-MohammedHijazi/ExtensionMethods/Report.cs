
using Kata_MohammedHijazi.Enums;
using Kata_MohammedHijazi.ExtensionMethods;
using Kata_MohammedHijazi.Transactions.Discount;

namespace Kata_MohammedHijazi;

public static class Report
{
    public static Currency currency= Currency.USD; 
         public static void ReportProductInfo(this Product product)
         {
             decimal normal = product.Price(PriceState.Normal);
             decimal net = product.Price(PriceState.Net);
             
              Console.WriteLine("==============================================");
              Console.WriteLine($"Name: {product.Info.Name} , UPC: {product.Info.Upc} , Price: ${normal}");
              Console.WriteLine($"Tax Amount: {product.Tax.Amount}, Discount Amount: ${product.Discount.Amount},");
              Console.WriteLine($"Price Before Tax = ${normal}, After Tax : ${product.Tax.TaxedPrice}");
              Console.WriteLine($"After Discount : ${product.Discount.DiscountedPrice}, Net: ${net}"); 
              Console.WriteLine("==============================================");
         }

         public static void ReportDiscount(this Product product)
         {
             string replace = product.Discount.Ratio != 0 ? product.Discount.Amount + "" : "No Discount is Applied"; 
             
             Console.WriteLine("===============================================");
             Console.WriteLine($"Tax Amount: {product.Tax.Amount}{currency}, Discount Amount: {replace}{currency}");
             Console.WriteLine($"Original Price:{product.Price(PriceState.Normal)}{currency}");
             Console.WriteLine($"Final Net Price: {product.Price(PriceState.Net)}{currency}");
             Console.WriteLine("===============================================");
         }

         public static void ReportSelectiveDiscount(this Product product)
         {
             Console.WriteLine("===============================================");   
             Console.WriteLine($"Tax = {product.Tax.Ratio * 100}%, universal discount = {product.Discount.Ratio * 100}%, UPC-discount = {Discount.SelectiveUpc.Value * 100}% for UPC={Discount.SelectiveUpc.Key}");
             Console.WriteLine($"Tax amount = {product.Tax.Amount} {currency}, discount = {product.Discount.Amount} {currency},"); 
             Console.WriteLine($"Final Net Price: {product.Price(PriceState.Net)} {currency}");
             Console.WriteLine($"Total Discount Amount: {product.Discount.Amount} {currency}");
             Console.WriteLine("===============================================");
         }

         public static void ReportPrecedence(this Product product)
         {
              Console.WriteLine("===============================================");
              Console.WriteLine($"Predecence Final Price: {product.Price(PriceState.Net)} {currency}");
              Console.WriteLine($"Total Discount Amount: {product.Discount.Amount} {currency}");
              Console.WriteLine("===============================================");
                      
         }

         public static void ReportExpenses(this Product product)
         {
             decimal packageCost = product.Info.Expenses.Packages * product.Price(PriceState.Normal);
             
             Console.WriteLine("===============================================");
             Console.WriteLine($"Cost =${product.Price(PriceState.Normal)} {currency}, Tax =${product.Tax.Amount} {currency}, Discount =${product.Discount.Amount} {currency}");
             Console.WriteLine($"Packaging =${packageCost.SetPrecision()} {currency}, Transport =${product.Info.Expenses.Tranport} {currency}");
             Console.WriteLine($"Total Discount Amount: {product.Discount.Amount} {currency}");
             Console.WriteLine("===============================================");
                            
         }

         public static void GeneralReport(this Product product)
         {
             decimal package = product.Info.Expenses.ComputePackagingExpenses(product.Prices[PriceState.Normal]);
             Console.WriteLine("===============================================");
             Console.WriteLine($"Cost:{product.Prices[PriceState.Normal]} {currency}, Tax:{product.Tax.Amount} {currency},Discount:{product.Discount.Amount} {currency}");
             Console.WriteLine($"Packaging: {package} {currency}, Transpor: {product.Info.Expenses.Tranport} {currency}");
             Console.WriteLine($"Total:{product.Prices[PriceState.Net]} {currency}");
             Console.WriteLine("===============================================");
         }    
}