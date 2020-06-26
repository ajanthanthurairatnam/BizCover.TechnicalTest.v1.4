using System;
using System.Collections;
using System.Collections.Generic;
using BizCover.Cars.Contract;
using BizCover.Cars.Service.Rules;
using Xunit;

namespace BizCover.Cars.Tests
{
    public class YearRuleTest
    {
        private readonly YearRule _yearRule;
        public YearRuleTest()
        {
            _yearRule = new YearRule(2000, 10);
        }

        [Theory]
        [ClassData(typeof(CarsPurchaseYearRuleTestData))]
        public void CalculateYearRuleDiscount_ReturnsDiscountGrandTotal(CarsPurchaseResponse input, CarsPurchaseResponse expected)
        {
            var output = _yearRule.CalculateDiscount(input);

            Assert.Equal(expected.GrandTotal, output.GrandTotal);

            Assert.Equal(expected.TotalDiscount, output.TotalDiscount);
        }
    }

    public class CarsPurchaseYearRuleTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new CarsPurchaseResponse()
                {
                    CarPurchaseCollection=new List<CarPurchaseResponse>()
                    {
                        new CarPurchaseResponse(){Id=1,Price=35000,Year=1998},
                        new CarPurchaseResponse(){Id=2,Price=50000,Year=2002},
                        new CarPurchaseResponse(){Id=3,Price=65000,Year=1995}
                    },
                    GrandTotal=0,
                    TotalDiscount=0
                },
                new CarsPurchaseResponse() 
                {
                     CarPurchaseCollection=new List<CarPurchaseResponse>()
                    {
                        new CarPurchaseResponse(){Id=1,Price=35000,Year=1998,LineDiscount=3500},
                        new CarPurchaseResponse(){Id=2,Price=50000,Year=2002,LineDiscount=0},
                        new CarPurchaseResponse(){Id=3,Price=65000,Year=1995,LineDiscount=6500}
                    },
                    GrandTotal=140000,
                    TotalDiscount=10000

                } 
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
