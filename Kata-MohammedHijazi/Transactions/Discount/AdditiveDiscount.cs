using System.Transactions;
using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions.Discount;

public class AdditiveDiscount : Discount
{
   public AdditiveDiscount(decimal price, decimal discount, int upc)
   {
      discount += upc.ValidateUpc() ? SelectiveUpc.Value : 0;  
      
      Ratio = Cap.CheckForCap(discount, true);
      Amount = Cap.CheckForCap(price * Ratio, false); 
      
     DiscountedPrice = ComputeDiscountPrice(price); 
   }
}