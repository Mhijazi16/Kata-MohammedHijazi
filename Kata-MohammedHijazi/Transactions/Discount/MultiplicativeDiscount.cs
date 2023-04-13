namespace Kata_MohammedHijazi.Transactions.Discount;

public class Multiplicative : Discount
{
   
   public Multiplicative(decimal price, decimal discount, decimal selective)
   {
      Ratio = discount;
      Amount = Ratio * price;
      Ratio = selective;
      Amount = Amount + (price - Amount) * Ratio;
   }
}