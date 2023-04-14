
namespace Kata_MohammedHijazi.Transactions.Discount;

public class Discount : ValueManipulator
{
    public static KeyValuePair<int, decimal> SelectiveUpc { get; set; } = new KeyValuePair<int, decimal>(); 
    public decimal DiscountedPrice { get; set; }
    public Discount()
    {
        Ratio = 0;
        Amount = 0;
    }
    public Discount(decimal price, decimal ratio )
    {
        Ratio = ratio;
        Amount = price * Ratio;
        DiscountedPrice = ComputeDiscountPrice(price);
    }
    public decimal ComputeDiscountPrice(decimal price) => price - Amount;
}