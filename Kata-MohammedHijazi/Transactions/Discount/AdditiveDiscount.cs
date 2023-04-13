namespace Kata_MohammedHijazi.Transactions.Discount;

public class AdditiveDiscount : Discount
{
   public AdditiveDiscount(decimal price, decimal discount, decimal selective)
   {
      Ratio = discount + selective;
      Amount = Ratio * price; 
   } 
      
}