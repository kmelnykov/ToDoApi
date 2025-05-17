public class PromotionService
{
    public decimal Apply(Order order)
    {
        var total = order.Total;

        total = ApplyWeekdayDiscount(total);
        total = ApplyHighValueDiscount(total);

        return total;
    }

    private static bool IsWeekdaySaleDay() =>
        DateTime.Today.DayOfWeek is DayOfWeek.Monday or DayOfWeek.Tuesday;

    private static decimal ApplyWeekdayDiscount(decimal amount) =>
        IsWeekdaySaleDay() ? amount * 0.95m : amount;

    private static decimal ApplyHighValueDiscount(decimal amount) =>
        amount > 500 ? amount - 25m : amount;
}


public record Order(decimal Total);