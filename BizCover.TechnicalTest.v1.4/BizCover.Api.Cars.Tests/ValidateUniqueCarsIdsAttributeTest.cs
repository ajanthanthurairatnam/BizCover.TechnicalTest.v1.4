using System.Collections;
using System.Collections.Generic;
using BizCover.Cars.Contract;
using Xunit;

namespace BizCover.Cars.Tests
{
    public class ValidateUniqueCarsIdsAttributeTest
    {
        private readonly ValidateUniqueCarsIdsAttribute _validateUniqueCarsIdsAttribute;

        public ValidateUniqueCarsIdsAttributeTest()
        {
            _validateUniqueCarsIdsAttribute = new ValidateUniqueCarsIdsAttribute();
        }

        [Theory]
        [ClassData(typeof(ValidateUniqueCarsIdsAttributeTestData))]
        public void ValidateUniqueCarsIdsAttribute_ReturnsValid(List<int> input, bool expected)
        {
            var output = _validateUniqueCarsIdsAttribute.IsValid(input);

            Assert.Equal(expected, output);
        }
    }

    public class ValidateUniqueCarsIdsAttributeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<int>()
                {
                    1,2,3
                },
                true
            };
            yield return new object[]
             {
                    new List<int>()
                    {
                        1,4,3,4,5
                    },
                    false
             };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
