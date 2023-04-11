using System.IO.Compression;
using Kata_MohammedHijazi.ExtensionMethods;

namespace Kata_MohammedHijazi.Transactions;

public class SelectiveDiscount 
{
   public int SelectiveUPC { get; set;}
   private decimal rate;
   private decimal amount;
   public bool isActiveated = false; 
   public decimal Ratio{ get => rate; set => rate = value.ValidateRatio(); }
   public decimal Amount { get => amount.SetPrecision() ; set => amount = rate * value; }

   public SelectiveDiscount(int selectiveUpc, decimal ratio ,decimal price, int upc)
   {
      SelectiveUPC = selectiveUpc;
      Ratio = ratio;
      if (isActive(upc))
          Amount = price; 
   }   

   public bool isActive(int upc) =>  isActiveated = upc == SelectiveUPC;
   public decimal ApplySelective(decimal discountedPrice)
   {
       if(isActiveated)
           return discountedPrice - Amount;
       return 0; 
   }
}