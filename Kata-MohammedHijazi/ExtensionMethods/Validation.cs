using System.Dynamic;
using Kata_MohammedHijazi.Transactions.Discount;

namespace Kata_MohammedHijazi.ExtensionMethods;

public static class Validation
{
   #region GeneralValidationMethods
   public static bool InRange(this decimal value, decimal lower, decimal upper) => value >=lower && value <= upper;
   public static bool IsPossitve(this decimal value) => value >= 0;
   public static bool IsLargerThan(this decimal value, decimal min) => value > min; 
   public static decimal SetPrecision(this decimal value, int amount) => Decimal.Round(value, amount);
   public static bool IsPercentage(this decimal value) => value > 0 && value < 1;

   #endregion
   public static bool ValidateUpc(this int value) => Discount.SelectiveUpc.Key == value; 
   public static decimal ValidatePrice(this decimal price)
   {
      if (price.IsPossitve() == false)
         throw new ArgumentException("The Price Must Be Positive!!");
      return price.SetPrecision(4); 
   }
   public static decimal ValidateRatio(this decimal ratio)
   {
      if (ratio.IsPossitve() == false)
         throw new ArgumentException("The Tax Must be Positive");
      if (ratio.IsLargerThan(1))
         ratio /= 100;
      return ratio.SetPrecision(4); 
   }
}