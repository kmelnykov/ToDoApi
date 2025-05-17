public class ReceiptPrinter
{
    private readonly decimal _taxRate;

    public ReceiptPrinter(decimal taxRate = 0.2m)
        => _taxRate = taxRate;

    public string PrintReceipt(Order order)
    {
        var total = order.Total + CalculateTax(order) + ShippingCalculator.FlatRate;
        return $"Total amount: {total:C}";
    }

    private decimal CalculateTax(Order order) =>
        order.Total * _taxRate;
}

public static class ShippingCalculator
{
    public const decimal FlatRate = 10m;
}

public record Order(decimal Total);