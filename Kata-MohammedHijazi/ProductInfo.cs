using Kata_MohammedHijazi.Transactions;

namespace Kata_MohammedHijazi;

public class ProductInfo
{
     public string Name { get; set; }
     public int UPC { get; set; }
     public Expenses Expenses { get; set; }
     public ProductInfo(string name, int upc,Expenses expenses)
     {
         Name = name;
         UPC = upc;
         Expenses = expenses;
     }
}