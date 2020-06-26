using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BizCover.Cars.Contract;
using BizCover.Cars.Service;
using BizCover.Cars.Api;

namespace BizCover.Api.Cars.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService _carsService;
        private readonly ICarDiscountRuleService _carDiscountRuleProcessor;

        public CarsController(ICarsService carsService, ICarDiscountRuleService carDiscountRuleProcessor, ILoggerManager logger)
        {
            _carsService = carsService;
            _carDiscountRuleProcessor = carDiscountRuleProcessor;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateDiscount([FromBody]CarsPurchaseRequest carPurchaseRequest)
        {
            var getCarResponse = await _carsService.GetCars(carPurchaseRequest.Ids);
            var purchaseResponse = _carDiscountRuleProcessor.CalculateDiscount(getCarResponse);

            return Ok(purchaseResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]CarPostRequest carPostRequest)
        {
            var postResponse = await _carsService.PostCar(carPostRequest);

            return Ok(postResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CarPostRequest carPostRequest)
        {
            var postResponse = await _carsService.PostCar(carPostRequest);

            return Ok(postResponse);
        }
    }
}
