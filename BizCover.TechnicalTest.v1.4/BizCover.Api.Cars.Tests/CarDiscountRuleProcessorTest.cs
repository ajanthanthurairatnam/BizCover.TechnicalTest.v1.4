using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BizCover.Cars.Contract;
using BizCover.Cars.Data.Domain;
using BizCover.Cars.Service;
using BizCover.Cars.Service.Rules;
using Moq;
using Xunit;

namespace BizCover.Cars.Tests
{
    public class CarDiscountRuleProcessorTest
    {
        public CarDiscountRuleProcessorTest()
        {
        }

        [Theory]
        [ClassData(typeof(CarDiscountRuleProcessorTestData))]
        public void CalculateCumulativeDiscount_ReturnsDiscountGrandTotal(CarsPurchaseResponse input, CarsPurchaseResponse expected)
        {
            //Arrange Data
            var _mockMapper = new Mock<IMapper>();
            var _carDiscountRules = new Mock<IEnumerable<ICarDiscountRule>>();
            var discountRules = new List<ICarDiscountRule>()
            {
               new YearRule(2000, 10, true),
               new CountRule(2, 3, true),
               new CostRule(100000, 5, true)
            };

            _carDiscountRules.Setup(m => m.GetEnumerator()).Returns(() => discountRules.GetEnumerator());

            _mockMapper.Setup(x => x.Map<CarsPurchaseResponse>(It.IsAny<IEnumerable<SelectCar>>()))
                  .Returns((IEnumerable<SelectCar> source) =>
                  {
                      var purchaseResponse = new CarsPurchaseResponse()
                      {
                          CarPurchaseCollection = source.Select(
                              e => new CarPurchaseResponse()
                              {
                                  Id = e.Id,
                                  LineDiscount = 0,
                                  Price = e.Price,
                                  Year = e.Year
                              }),
                          GrandTotal = 0,
                          TotalDiscount = 0
                      };
                      return purchaseResponse;
                  });

            var _carDiscountRuleProcessorService = new CarDiscountRuleProcessorService(_carDiscountRules.Object, _mockMapper.Object);


            //Act
            var output = _carDiscountRuleProcessorService.CalculateDiscount(input.CarPurchaseCollection.Select(e => new SelectCar() { Id = e.Id, Price = e.Price, Year = e.Year }));


            Assert.Equal(expected.GrandTotal, output.GrandTotal);

            Assert.Equal(expected.TotalDiscount, output.TotalDiscount);
        }
    }


    public class CarDiscountRuleProcessorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new CarsPurchaseResponse()
                {
                    CarPurchaseCollection=new List<CarPurchaseResponse>()
                    {
                        new CarPurchaseResponse(){Id=1,Price=60000,Year=2005},
                        new CarPurchaseResponse(){Id=2,Price=70000,Year=1998},
                        new CarPurchaseResponse(){Id=3,Price=30000,Year=1991},
                        new CarPurchaseResponse(){Id=4,Price=40000,Year=2008}

                    },
                    GrandTotal=200000,
                    TotalDiscount=0
                },
                new CarsPurchaseResponse()
                {
                     CarPurchaseCollection=new List<CarPurchaseResponse>()
                    {
                        new CarPurchaseResponse(){Id=1,Price=60000,Year=2005,LineDiscount=0},
                        new CarPurchaseResponse(){Id=2,Price=70000,Year=1998,LineDiscount=7000},
                        new CarPurchaseResponse(){Id=3,Price=30000,Year=1991,LineDiscount=3000},
                        new CarPurchaseResponse(){Id=4,Price=40000,Year=2008,LineDiscount=0}
                    },
                    GrandTotal=175085,
                    TotalDiscount=24915

                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }



}
