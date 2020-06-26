using System.Collections;
using System.Collections.Generic;
using BizCover.Cars.Contract;
using BizCover.Cars.Service;
using Xunit;

namespace BizCover.Cars.Tests
{
    public class CostRuleTest
    {
        private readonly CostRule _costRule;
        public CostRuleTest()
        {
            _costRule = new CostRule(100000, 5);
        }

        [Theory]
        [ClassData(typeof(CarsCostRuleTest))]
        public void CalculateCostRuleDiscount_ReturnsDiscountGrandTotal(CarsPurchaseResponse input, CarsPurchaseResponse expected)
        {
            var output = _costRule.CalculateDiscount(input);
            
            Assert.Equal(expected.GrandTotal, output.GrandTotal);

            Assert.Equal(expected.TotalDiscount, output.TotalDiscount);
        }
    }

    public class CarsCostRuleTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new CarsPurchaseResponse()
                {
                    CarPurchaseCollection=new List<CarPurchaseResponse>()
                    {
                        new CarPurchaseResponse(){Id=1,Price=30000,Year=2003},
                        new CarPurchaseResponse(){Id=2,Price=80000,Year=1999}
                    },
                    GrandTotal=110000,
                    TotalDiscount=0
                },
                new CarsPurchaseResponse()
                {
                    CarPurchaseCollection=new List<CarPurchaseResponse>()
                    {
                        new CarPurchaseResponse(){Id=1,Price=30000,Year=2003},
                        new CarPurchaseResponse(){Id=2,Price=80000,Year=1999}
                    },
                    GrandTotal=104500,
                    TotalDiscount=5500
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

    }
    
}