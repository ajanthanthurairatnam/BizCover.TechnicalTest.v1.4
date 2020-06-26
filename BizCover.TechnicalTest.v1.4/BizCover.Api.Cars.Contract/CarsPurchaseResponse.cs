using System.Collections.Generic;

namespace BizCover.Cars.Contract
{
    public class CarsPurchaseResponse
    {
        public IEnumerable<CarPurchaseResponse> CarPurchaseCollection { get; set; }
        public double GrandTotal { get; set; }
        public double TotalDiscount { get; set; }
    }
}
