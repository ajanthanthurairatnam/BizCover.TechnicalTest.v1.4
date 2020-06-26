namespace BizCover.Cars.Service.Rules
{
    public static class RuleHelper
    {
        public static double CalculateDiscount(this double subTotal, double discountPercentage)
        {
            return subTotal * (discountPercentage / 100);
        }
    }
}
