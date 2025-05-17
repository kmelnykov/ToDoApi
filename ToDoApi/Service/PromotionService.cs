public class PromotionService
{
    private bool _hasDiscount;

    public decimal Apply(Order order)
    {
        decimal result = order.Total;

        if (DateTime.Today.DayOfWeek == DayOfWeek.Monday ||
            DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
        {
            _hasDiscount = true;
            result -= order.Total * 0.05m;
        }

        if (order.Total > 500)
        {
            _hasDiscount = true;
            result -= 25m;
        }

        if (_hasDiscount)
            Console.WriteLine("Discount applied!");

        return result;
    }
}