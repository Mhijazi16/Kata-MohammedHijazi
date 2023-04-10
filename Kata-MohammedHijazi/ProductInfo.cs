namespace Kata_MohammedHijazi;

public class ProductInfo
{
     public string Name { get; set; }
     public int UPC { get; set; }

     public ProductInfo(string name, int upc)
     {
         Name = name;
         UPC = upc;
     }
}