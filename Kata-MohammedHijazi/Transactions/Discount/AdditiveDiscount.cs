using System.Transactions;
using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions.Discount;

public class AdditiveDiscount : Discount
{
   public AdditiveDiscount(decimal price, decimal discount, int upc)
   {
      discount += upc.ValidateUpc() ? SelectiveUpc.Value : 0;  
      Ratio = discount;
      Amount = Ratio * price;
      DiscountedPrice = ComputeDiscountPrice(price); 
   } 
}