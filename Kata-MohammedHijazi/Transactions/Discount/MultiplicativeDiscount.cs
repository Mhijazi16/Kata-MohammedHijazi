using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions.Discount;

public class Multiplicative : Discount
{
   
   public Multiplicative(decimal price, decimal discount, int upc)
   {
      Ratio = discount;
      Amount = Ratio * price;
      if (upc.ValidateUpc())
      {
           Ratio = SelectiveUpc.Value;
           Amount = Amount + (price - Amount) * Ratio;
      }
         
   }
}