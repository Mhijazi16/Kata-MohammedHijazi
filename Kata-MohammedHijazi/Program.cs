using Kata_MohammedHijazi.Enums;
using Kata_MohammedHijazi.ExtensionMethods;
using Kata_MohammedHijazi.Transactions;
using Kata_MohammedHijazi.Transactions.Discount;

namespace Kata_MohammedHijazi;
public class Program
{
    public static void Main()
    {
        Discount.SelectiveUpc = new KeyValuePair<int, decimal>(123, 0.07m);
        Cap.Value = 0.3m; 
        
        Report.currency = Currency.USD; 
        Product p1 = new Product(
            new ProductInfo("AA", 123, new Expenses(0.01m,2.2m,20.25m)),
            new Tax(20.25m, 21),
            new Discount(20.25m, 15),
            20.25m,
            ComputeState.Additive);

        p1.GeneralReport(); 
    }
}