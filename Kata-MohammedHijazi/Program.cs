
using System.Net.NetworkInformation;
using Kata_MohammedHijazi;
using Kata_MohammedHijazi.Transactions;
public class Program
{
    public static void Main()
    {
        ProductInfo info = new ProductInfo("AA", 123,new Expenses(0.01m,2.2m));
        Tax tax = new Tax(20.25m);
        SelectiveDiscount selective = new SelectiveDiscount(123, 7, 20.25m, info.UPC);
        Discount discount = new Discount(20.25m, 15, selective);
        Product p = new Product(info, tax, discount, 20.25m,true);
        
        p.ReportExpenses();
    }
}