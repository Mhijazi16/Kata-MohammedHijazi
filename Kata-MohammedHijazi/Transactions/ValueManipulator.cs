using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions;

public abstract class ValueManipulator
{
    private decimal _ratio;
    private decimal _amount; 
    
    public decimal Ratio
    {
        get => _ratio;
        set => _ratio = value.ValidateRatio();
    }

    public decimal Amount
    {
        get => _amount;
        set => _amount = value.SetPrecision(4);
    }
}