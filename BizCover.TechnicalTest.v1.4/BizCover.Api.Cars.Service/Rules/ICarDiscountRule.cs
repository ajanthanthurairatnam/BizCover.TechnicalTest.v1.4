using BizCover.Cars.Contract;

namespace BizCover.Cars.Service
{
    public interface ICarDiscountRule
    {
        int Priority { get; }
        bool Active { get;  }
        CarsPurchaseResponse CalculateDiscount(CarsPurchaseResponse carDiscount);
    }
}
