using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions.Discount;

public class Cap
{
    public static decimal Value { get; set; }
    public static bool isRatio { get; set; }  

    public static decimal CheckForCap(decimal value, bool ratio)
    {
        isRatio = Value.IsPercentage();
        if (isRatio == ratio)
            return ComputeForCap(value);
        return value;
    }
    private static decimal ComputeForCap(decimal value)
        {
            if (value >= Value)
                return Value;
            return value;
        }

}