public class ReceiptPrinter{
    public string PrintReceipt(Order order){
        decimal tax = order.Total * 0.2m;
        decimal shipping = 10m;
        decimal grand = order.Total + tax + shipping;

        return "Total amount: " + grand.ToString("C");
    }
}

public record Order(decimal Total);