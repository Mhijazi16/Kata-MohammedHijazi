using Kata_MohammedHijazi.Transactions;
using Kata_MohammedHijazi.Transactions.Discount;

namespace Kata_MohammedHijazi.ExtensionMethods;

public static class PriceHandler
{
    
    #region AssignPrices 

    public static void AssignPrices(this Product product, dynamic values)
    {
        product.Price(PriceState.Normal, values.normal);
        product.Price(PriceState.Net, values.net); 
    }

    #endregion

    #region SettingUpPrices
    
    public static void SetupDefault(this Product product, decimal price)
    {
        decimal net = product.ComputeNetPrice(price); 
        product.AssignPrices(new {normal = price, net = net});
    }
    public static void SetupAdditive(this Product product, decimal price)
    {
        product.Discount = new AdditiveDiscount(price, product.Discount.Ratio, product.Info.Upc);
        decimal net = product.ComputeNetPrice(price); 
        product.AssignPrices(new {normal = price, net = net});
        Console.WriteLine(product.Discount.Amount);
    }
    public static void SetupMultiplicative(this Product product, decimal price)
    {
        product.Discount = new Multiplicative(price, product.Discount.Ratio, product.Info.Upc);
        decimal net = product.ComputeNetPrice(price);  
        product.AssignPrices(new {normal = price, net = net}); 
    }
    public static void SetupPrecedence(this Product product, decimal price)
    {
        if (product.Info.Upc.ValidateUpc() == true)
        {
            decimal selectiveAmount = price * Discount.SelectiveUpc.Value;
            product.Tax = new Tax(price - selectiveAmount, product.Tax.Ratio);
            product.Discount = new Discount(price - selectiveAmount, product.Discount.Ratio);
            product.Discount.Amount += selectiveAmount; 
        }

        decimal net = product.ComputeNetPrice(price);
        product.AssignPrices(new {normal = price, net = net});
    }

    #endregion
    public static decimal ComputeNetPrice(this Product product, decimal price) =>
        price + product.Tax.Amount - product.Discount.Amount + product.Info.Expenses.Amount; 

}