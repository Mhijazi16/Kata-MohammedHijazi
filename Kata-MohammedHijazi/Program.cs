using Kata_MohammedHijazi.Transactions;
using Kata_MohammedHijazi.Transactions.Discount;

namespace Kata_MohammedHijazi;
public class Program
{
    public static void Main()
    {
        Discount.SelectiveUpc = new KeyValuePair<int, decimal>(123, 0.07m); 
        
        Product p1 = new Product(
            new ProductInfo("AA", 123, new Expenses(0,0,20.25m)),
            new Tax(20.25m, 20),
            new Discount(20.25m, 15),
            20.25m,
            ComputeState.Precedence);

            p1.GeneralReport(); 
    }
}