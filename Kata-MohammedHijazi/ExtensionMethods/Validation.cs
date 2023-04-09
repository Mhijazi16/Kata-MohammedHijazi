using System.Dynamic;

namespace Kata_MohammedHijazi.ExtensionMethods;

public static class Validation
{
   public static bool InRange(this decimal value, decimal lower, decimal upper) => value >=lower && value <= upper;
   public static bool IsPossitve(this decimal value) => value >= 0;
   public static decimal SetPrecision(this decimal value) => Decimal.Round(value, 2); 
}