
namespace Kata_MohammedHijazi.Transactions.Discount;

public class SelectiveDiscount : Discount 
{
    public int SelectiveUpc { get; set;}

    public SelectiveDiscount(int selectiveUpc, decimal ratio ,decimal price, int upc)
    {
       SelectiveUpc = selectiveUpc;
       Ratio = ratio;
       if (SelectiveUpc == upc)
           Amount = price * Ratio; 
    }   

}