using System.Linq;
using BizCover.Cars.Contract;

namespace BizCover.Cars.Service.Rules
{
    public class YearRule : ICarDiscountRule
    {
        private readonly int _year;
        private readonly double _discountPercentage;

        public int Priority { get; }
        public bool Active { get; }

        public YearRule(int year, double discountPercentage,bool isActive=true,int priority=1000)
        {
            _year = year;
            _discountPercentage = discountPercentage;

            Active = isActive;
            Priority = priority;
        }

        public CarsPurchaseResponse CalculateDiscount(CarsPurchaseResponse carDiscount)
        {
            carDiscount.GrandTotal = carDiscount.CarPurchaseCollection.Sum(e => e.Price) - carDiscount.CarPurchaseCollection.Sum(e => e.LineDiscount);
            carDiscount.TotalDiscount = carDiscount.CarPurchaseCollection.Sum(e => e.LineDiscount);

            foreach (var carLine in carDiscount.CarPurchaseCollection)
            {
                var percentage = carLine.Year <= _year ? _discountPercentage : 0;
                carLine.LineDiscount = carLine.Price.CalculateDiscount(percentage);
                carLine.Price.CalculateDiscount(percentage);

                carDiscount.GrandTotal -= carLine.LineDiscount;
                carDiscount.TotalDiscount += (carLine.LineDiscount);
            }

            return carDiscount;
        }
    }
}
