
namespace Kata_MohammedHijazi.Transactions.Discount;

public class Discount : ValueManipulator
{
    public static KeyValuePair<int, decimal> SelectiveUpc { get; set; } = new KeyValuePair<int, decimal>(); 
    public Discount()
    {
        Ratio = 0;
        Amount = 0;
    }
    public Discount(decimal price, decimal ratio )
    {
        Ratio = ratio;
        Amount = price;
    }
    public decimal ComputeDiscountPrice(decimal price) => price - Amount;
}