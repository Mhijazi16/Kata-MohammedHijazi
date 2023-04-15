using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions;

public class Expenses
{
    private decimal PackagesRatio;
    private decimal transporting;
    public decimal Amount { get; set; }
    public decimal Packages
    {
        get => PackagesRatio;
        set => PackagesRatio = value.ValidateRatio();
    }
    public decimal Tranport
    {
        get => transporting;
        set => transporting = value.SetPrecision(4);
    }

    public Expenses(decimal packaging, decimal transporting, decimal price)
    {
        Packages = packaging;
        Tranport = transporting;
        Amount = ComputePackagingExpenses(price) + Tranport;
    }
    public decimal ComputePackagingExpenses(decimal price) =>  (price * PackagesRatio).SetPrecision(4);
}