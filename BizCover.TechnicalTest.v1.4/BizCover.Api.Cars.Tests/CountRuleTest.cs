using System.Collections;
using System.Collections.Generic;
using BizCover.Cars.Contract;
using BizCover.Cars.Service;
using Xunit;

namespace BizCover.Cars.Tests
{
    public class CountRuleTest 
    {
        private readonly CountRule _countRule;
        public CountRuleTest()
        {
            _countRule = new CountRule(2, 3);
        }

        [Theory]
        [ClassData(typeof(CarsPurchaseCountRuleTestData))]
        public void CalculateCountRuleDiscount_ReturnsDiscountGrandTotal(CarsPurchaseResponse input, CarsPurchaseResponse expected)
        {
            var output = _countRule.CalculateDiscount(input);

            Assert.Equal(expected.GrandTotal, output.GrandTotal);

            Assert.Equal(expected.TotalDiscount, output.TotalDiscount);
        }
    }

    public class CarsPurchaseCountRuleTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new CarsPurchaseResponse()
                {
                    CarPurchaseCollection=new List<CarPurchaseResponse>()
                    {
                        new CarPurchaseResponse(){Id=1,Price=40000,Year=2005},
                        new CarPurchaseResponse(){Id=2,Price=20000,Year=2007},
                        new CarPurchaseResponse(){Id=3,Price=30000,Year=2001}
                       
                    },
                    GrandTotal=90000,
                    TotalDiscount=0
                },
                new CarsPurchaseResponse()
                {
                     CarPurchaseCollection=new List<CarPurchaseResponse>()
                    {
                        new CarPurchaseResponse(){Id=1,Price=40000,Year=2005},
                        new CarPurchaseResponse(){Id=2,Price=20000,Year=2007},
                        new CarPurchaseResponse(){Id=3,Price=30000,Year=2001}
                    },
                    GrandTotal=87300,
                    TotalDiscount=2700

                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
