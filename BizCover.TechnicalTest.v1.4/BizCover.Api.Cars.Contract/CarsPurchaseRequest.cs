using System.Collections.Generic;
namespace BizCover.Cars.Contract
{
    public class CarsPurchaseRequest
    {
        [ValidateCarsIdsTolerance(tolerance:100, ErrorMessage = "Number of Car Ids must be less than hundred.")]
        [ValidateUniqueCarsIds(ErrorMessage ="Car Ids must be unique.")]
        public List<int> Ids { get; set; }
    }
}
