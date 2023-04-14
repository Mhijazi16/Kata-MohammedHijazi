
namespace Kata_MohammedHijazi.Transactions;

public class Tax : ValueManipulator
{
    public decimal TaxedPrice { get; set; }
    public Tax(decimal price)
    {
        Ratio = 0.2m;
        Amount = price * Ratio; 
        TaxedPrice = ComputeTaxedPrice(price);
    }
    public Tax(decimal price, decimal ratio)
    {
        Ratio = ratio;
        Amount = price * Ratio;
        TaxedPrice = ComputeTaxedPrice(price); 
    }

    public decimal ComputeTaxedPrice(decimal price) => price + Amount;

}
