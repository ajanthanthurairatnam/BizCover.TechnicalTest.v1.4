using System.Linq;
using BizCover.Cars.Contract;
using BizCover.Cars.Service.Rules;

namespace BizCover.Cars.Service
{
    public class CountRule : ICarDiscountRule
    {
        private readonly int _carCount;
        private readonly double _discountPercentage;

        public int Priority { get; }
        public bool Active { get; }

        public CountRule(int carCount,double discountPercentage, bool isActive=true,int priority=2000)
        {
            _carCount = carCount;
            _discountPercentage = discountPercentage;
            Active = isActive;
            Priority = priority;
        }

        public CarsPurchaseResponse CalculateDiscount(CarsPurchaseResponse carDiscount)
        {
            var grandTotal = carDiscount.GrandTotal;
            var noOfCars = carDiscount.CarPurchaseCollection.Count();
            var percentage = noOfCars >= _carCount ? _discountPercentage : 0;

            carDiscount.TotalDiscount += grandTotal.CalculateDiscount(percentage);
            carDiscount.GrandTotal -= grandTotal.CalculateDiscount(percentage);

            return carDiscount;
        }
    }
}
