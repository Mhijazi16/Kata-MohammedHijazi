using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions;

public class Discount
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

    public Discount(decimal price, decimal ratio)
    {
        Ratio = ratio;
        Amount = price;
    } 

    #endregion

    #region Methods

    public decimal ApplyDiscount(decimal TaxedPrice) => TaxedPrice - Amount;    

    #endregion

}