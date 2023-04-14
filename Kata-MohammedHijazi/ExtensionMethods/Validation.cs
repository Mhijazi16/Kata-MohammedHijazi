using System.Dynamic;
using Kata_MohammedHijazi.Transactions.Discount;

namespace Kata_MohammedHijazi.ExtensionMethods;

public static class Validation
{
   public static bool InRange(this decimal value, decimal lower, decimal upper) => value >=lower && value <= upper;
   public static bool IsPossitve(this decimal value) => value >= 0;
   public static bool IsLargerThan(this decimal value, decimal min) => value > min; 
   public static decimal SetPrecision(this decimal value) => Decimal.Round(value, 2);
   public static bool isNotZero(this decimal value) => value != 0;
   public static bool ValidateUpc(this int value) => Discount.SelectiveUpc.Key == value; 

   public static decimal ReturnNotZero(this decimal val1, decimal val2, decimal val3)
   {
      if (val1.isNotZero())
         return val1;
      if (val2.isNotZero())
         return val2;
      return val3;
   }

   public static decimal ValidatePrice(this decimal price)
   {
      if (price.IsPossitve() == false)
         throw new ArgumentException("The Price Must Be Positive!!");
      return price.SetPrecision(); 
   }
   public static decimal ValidateRatio(this decimal ratio)
   {
      if (ratio.IsPossitve() == false)
         throw new ArgumentException("The Tax Must be Positive");
      if (ratio.IsLargerThan(1))
         ratio /= 100;
      return ratio.SetPrecision(); 
   }
}