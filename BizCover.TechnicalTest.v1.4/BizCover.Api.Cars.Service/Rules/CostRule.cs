using BizCover.Cars.Contract;
using BizCover.Cars.Service.Rules;

namespace BizCover.Cars.Service
{
    public class CostRule : ICarDiscountRule
    {
        private readonly double _minCost;
        private readonly double _discountPercentage;

        public int Priority { get; } 
        public bool Active { get; }

        public CostRule(double minCost, double discountPercentage,bool isActive = true, int priority = 3000)
        {
            _minCost = minCost;
            _discountPercentage = discountPercentage;
            Active = isActive;
            Priority = priority;
        }

        public CarsPurchaseResponse CalculateDiscount(CarsPurchaseResponse carDiscount)
        {
            var grandTotal = carDiscount.GrandTotal;
            var percentage= grandTotal >= _minCost ? _discountPercentage : 0.00;
            carDiscount.TotalDiscount += grandTotal.CalculateDiscount(percentage);
            carDiscount.GrandTotal -= grandTotal.CalculateDiscount(percentage);

            return carDiscount;
        }       
    }

}
