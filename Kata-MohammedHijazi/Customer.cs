namespace Kata_MohammedHijazi;

public class Customer
{
    public string Name { get; set; } 
    public List<Product> Products { get; set; }
    private decimal tax;

    public decimal Tax
    {
        get => tax;
        set => tax.ValidateTax(); 
    }
}