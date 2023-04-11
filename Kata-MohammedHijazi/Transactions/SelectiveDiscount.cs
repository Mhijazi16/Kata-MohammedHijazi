using System.IO.Compression;
using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions;

public class SelectiveDiscount 
{
    #region Fields

    public int SelectiveUPC { get; set;}
    private decimal rate;
    private decimal amount;
    public bool isActiveated = false; 

    #endregion

    #region Getters&Setters

    public decimal Ratio{ get => rate; set => rate = value.ValidateRatio(); }
    public decimal Amount { get => amount.SetPrecision() ; set => amount = rate * value; }

    #endregion

    #region Constructor

    public SelectiveDiscount(int selectiveUpc, decimal ratio ,decimal price, int upc)
    {
       SelectiveUPC = selectiveUpc;
       Ratio = ratio;
       if (isActive(upc))
           Amount = price; 
    }   

    #endregion

    #region Methods

    public bool isActive(int upc) =>  isActiveated = upc == SelectiveUPC;
    public decimal ApplySelective(decimal discountedPrice)
    {
        if(isActiveated)
            return discountedPrice - Amount;
        return 0; 
    }   

    #endregion

}