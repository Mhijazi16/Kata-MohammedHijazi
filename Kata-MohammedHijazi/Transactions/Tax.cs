
namespace Kata_MohammedHijazi.Transactions;

public class Tax : ValueManipulator
{
    public Tax(decimal price)
    {
        Ratio = 0.2m;
        Amount = price * Ratio; 
    }
    public Tax(decimal price, decimal ratio)
    {
        Ratio = ratio;
        Amount = price * Ratio; 
    }

    public decimal ComputeTaxedPrice(decimal price) => price + Amount;

}
