using System.Collections;
using System.Collections.Generic;
using BizCover.Cars.Contract;
using Xunit;

namespace BizCover.Cars.Tests
{
    public class ValidateCarsIdsToleranceTest
    {
        private readonly ValidateCarsIdsToleranceAttribute _validateCarsIdsToleranceAttribute;
       
        public ValidateCarsIdsToleranceTest()
        {
            _validateCarsIdsToleranceAttribute = new ValidateCarsIdsToleranceAttribute(5);
        }

        [Theory]
        [ClassData(typeof(ValidateCarsIdsToleranceAttributeTestData))]
        public void ValidateCarsIdsToleranceAttribute_ReturnsValid(List<int> input, bool expected)
        {
            var output = _validateCarsIdsToleranceAttribute.IsValid(input);

            Assert.Equal(expected, output);
        }
    }

    public class ValidateCarsIdsToleranceAttributeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<int>()
                {
                    1,2,3,4,5,6
                },
                false
            };
            yield return new object[]
             {
                    new List<int>()
                    {
                        1,2,3,4,
                    },
                    true
             };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
