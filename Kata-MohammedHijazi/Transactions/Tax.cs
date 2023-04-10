using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions;

public class Tax
{
    #region Fields

    private decimal ratio;
    private decimal amount;

    #endregion

    #region Getters&Setters 

    public decimal Ratio
    {
        get => ratio;
        set => ratio = value.ValidateRatio();
    }

    public decimal Amount
    {
        get => amount;
        set => amount = value * Ratio;
    }

    #endregion

    #region Constructors

    public Tax(decimal price)
    {
        Ratio = 0.2m;
        Amount = price; 
    }

    public Tax(decimal price, decimal ratio)
    {
        Ratio = ratio;
        Amount = price; 
    }

    #endregion

    #region Methods

    public decimal ApplyTax(decimal price) => price + Amount;

    #endregion
}
