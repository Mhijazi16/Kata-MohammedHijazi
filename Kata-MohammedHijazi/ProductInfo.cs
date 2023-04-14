using Kata_MohammedHijazi.Transactions;

namespace Kata_MohammedHijazi;

public class ProductInfo
{
     public string Name { get; set; }
     public int Upc { get; set; }
     public Expenses Expenses { get; set; }

     public ProductInfo(string name, int upc, Expenses expenses)
     {
          Name = name;
          Upc = upc;
          Expenses = expenses;
     }
}