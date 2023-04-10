
using System.Net.NetworkInformation;
using Kata_MohammedHijazi;

public class Program
{
    public static void Main()
    {
        ProductInfo info = new ProductInfo("aa",123);
        Product p1 = new Product(info, 15, 20.25m); 
        p1.PrintInfo();
    }
}