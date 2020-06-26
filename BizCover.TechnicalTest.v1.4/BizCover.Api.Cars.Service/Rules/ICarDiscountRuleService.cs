using System.Collections.Generic;
using BizCover.Cars.Contract;
using BizCover.Cars.Data.Domain;

namespace BizCover.Cars.Service
{
    public interface ICarDiscountRuleService
    {
        CarsPurchaseResponse CalculateDiscount(IEnumerable<SelectCar> carRequest);
    }
}
