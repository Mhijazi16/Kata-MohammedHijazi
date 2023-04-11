using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions;

public class Discount
{
    #region Fields

      private decimal ratio;
      private decimal amount;
      public bool isApplied { get; set; } 
      public SelectiveDiscount selectiveDiscount { get; set; }
      
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
          set => amount = ComputeAmount(value, Ratio).SetPrecision();
      }

    #endregion

    #region Constructors

    public Discount()
    {
        Ratio = 0;
        Amount = 0;
        isApplied = false;
    }
    public Discount(decimal price, decimal ratio )
         {
             Ratio = ratio;
             Amount = price;
             isApplied = ratio.isNotZero();
         }
    public Discount(decimal price, decimal ratio, SelectiveDiscount s)
     {
         Ratio = ratio;
         Amount = price;
         isApplied = ratio.isNotZero();
         selectiveDiscount = s; 
     }   

    #endregion

    #region Methods

    public decimal ComputeAmount(decimal value, decimal ratio) => value * ratio; 
    public decimal ApplyDiscount(decimal TaxedPrice)
    {
        return TaxedPrice - Amount;
    }

    #endregion

}