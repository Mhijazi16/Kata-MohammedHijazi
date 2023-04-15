using Kata_MohammedHijazi.Enums;
using Kata_MohammedHijazi.Transactions;
using Kata_MohammedHijazi.Transactions.Discount;

namespace Kata_MohammedHijazi;
public class Program
{
    public static void Main()
    {
        Discount.SelectiveUpc = new KeyValuePair<int, decimal>(123, 0.07m);
<<<<<<< HEAD
        Cap.Value = 0.3m; 
        
=======
        Report.currency = Currency.EUR; 
>>>>>>> fd2bde2 (Currency : Finishing up & Running the code)
        Product p1 = new Product(
            new ProductInfo("AA", 123, new Expenses(0,0,20.25m)),
            new Tax(20.25m, 21),
            new Discount(20.25m, 15),
            20.25m,
            ComputeState.Additive);

<<<<<<< HEAD
            
            p1.GeneralReport(); 
=======
        p1.GeneralReport(); 
>>>>>>> fd2bde2 (Currency : Finishing up & Running the code)
    }
}