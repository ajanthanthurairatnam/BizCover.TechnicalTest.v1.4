using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BizCover.Cars.Contract;
using BizCover.Cars.Data.Domain;

namespace BizCover.Cars.Service
{
    public class CarDiscountRuleProcessorService: ICarDiscountRuleService
    {
        private readonly IEnumerable<ICarDiscountRule> _carDiscountRules;
        private readonly IMapper _mapper;
       
        public CarDiscountRuleProcessorService(IEnumerable<ICarDiscountRule> carDiscountRules, IMapper mapper)
        {
            _carDiscountRules = carDiscountRules;
            _mapper = mapper;
        }

        public CarsPurchaseResponse CalculateDiscount(IEnumerable<SelectCar> carRequest)
        {
            var carDiscount = _mapper.Map<CarsPurchaseResponse>(carRequest);

            foreach (var carDiscountRule in _carDiscountRules.OrderBy(e=>e.Priority))
            {
                carDiscount= carDiscountRule.CalculateDiscount(carDiscount);
            }

            return carDiscount;
        }
    }
}
