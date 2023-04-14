using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions;

public class Expenses
{
    private decimal PackagesRatio;
    private decimal transporting;
    public decimal Total { get; set; }
    public decimal Packages
    {
        get => PackagesRatio;
        set => PackagesRatio = value.ValidateRatio();
    }
    public decimal Tranport
    {
        get => transporting;
        set => transporting = value.SetPrecision();
    }

    public Expenses(decimal packaging, decimal transporting)
    {
        Packages = packaging;
        Tranport = transporting;
        Total = Packages + Tranport;
    }
    public decimal ComputePackagingExpenses(decimal price) =>  (price * PackagesRatio);
}