using Kata_MohammedHijazi.Enums;
using Kata_MohammedHijazi.ExtensionMethods;
using Kata_MohammedHijazi.Transactions.Discount;
namespace Kata_MohammedHijazi.ExtensionMethods;

public static class Report
{
    public static Currency currency= Currency.USD; 
    
       
         public static void ReportProductInfo(this Product product)
         {
             decimal normal = product.Price(PriceState.Normal).SetPrecision(2);
             decimal net = product.Price(PriceState.Net).SetPrecision(2);
              var discountDiscountedPrice = product.Discount.DiscountedPrice.SetPrecision(2);
              var taxAmount = product.Tax.Amount.SetPrecision(2);
              var discountAmount = product.Discount.Amount.SetPrecision(2);
              var taxTaxedPrice = product.Tax.TaxedPrice.SetPrecision(2);
             
              Console.WriteLine("==============================================");
              Console.WriteLine($"Name: {product.Info.Name} , UPC: {product.Info.Upc} , Price: ${normal}");
              Console.WriteLine($"Tax Amount: {taxAmount}, Discount Amount: ${discountAmount},");
              Console.WriteLine($"Price Before Tax = ${normal}, After Tax : ${taxTaxedPrice}");
              Console.WriteLine($"After Discount : ${discountDiscountedPrice}, Net: ${net}"); 
              Console.WriteLine("==============================================");
         }

         public static void ReportDiscount(this Product product)
         {
             string replace = product.Discount.Ratio != 0 ? product.Discount.Amount.SetPrecision(2) + "" : "No Discount is Applied"; 
             
             var taxAmount = product.Tax.Amount.SetPrecision(2);
             var normal = product.Price(PriceState.Normal).SetPrecision(2);
             var net = product.Price(PriceState.Net).SetPrecision(2); 
             
             Console.WriteLine("===============================================");
             Console.WriteLine($"Tax Amount: {taxAmount}{currency}, Discount Amount: {replace}{currency}");
             Console.WriteLine($"Original Price:{normal}{currency}");
             Console.WriteLine($"Final Net Price: {net}{currency}");
             Console.WriteLine("===============================================");
         }

         public static void ReportPrecedence(this Product product)
         {
              var discountAmount = product.Discount.Amount.SetPrecision(2);
              var net = product.Price(PriceState.Net).SetPrecision(2);
              
              Console.WriteLine("===============================================");
              Console.WriteLine($"Predecence Final Price: {net} {currency}");
              Console.WriteLine($"Total Discount Amount: {discountAmount} {currency}");
              Console.WriteLine("===============================================");
                      
         }

         public static void ReportExpenses(this Product product)
         {
             decimal packageCost = product.Info.Expenses.Packages * product.Price(PriceState.Normal);
             
             Console.WriteLine("===============================================");
             Console.WriteLine($"Cost =${product.Price(PriceState.Normal)} {currency}, Tax =${product.Tax.Amount} {currency}, Discount =${product.Discount.Amount} {currency}");
             Console.WriteLine($"Packaging =${packageCost.SetPrecision(2)} {currency}, Transport =${product.Info.Expenses.Tranport} {currency}");
             Console.WriteLine($"Total Discount Amount: {product.Discount.Amount} {currency}");
             Console.WriteLine("===============================================");
                            
         }

         public static void GeneralReport(this Product product)
         {
             var productPrice = product.Prices[PriceState.Normal].SetPrecision(2);
             var package = product.Info.Expenses.ComputePackagingExpenses(productPrice);
             var net = product.Prices[PriceState.Net].SetPrecision(2);
             var expensesTranport = product.Info.Expenses.Tranport.SetPrecision(2);
             var taxAmount = product.Tax.Amount.SetPrecision(2);
             var discountAmount = product.Discount.Amount.SetPrecision(2);
             
             Console.WriteLine("===============================================");
             Console.WriteLine($"Cost:{productPrice} {currency}, Tax:{taxAmount} {currency},Discount:{discountAmount} {currency}");
             Console.WriteLine($"Packaging: {package} {currency}, Transpor: {expensesTranport} {currency}");
             Console.WriteLine($"Total:{net} {currency}");
             Console.WriteLine("===============================================");
         }    
}