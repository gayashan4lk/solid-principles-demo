using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArdalisRating.Tests
{
    public class JsonPolicySerializerTest
    {
        [Fact]
        public void ReturnsDefaultPolicyFromEmptyJsonString()
        {
            var inputJson = "{}";
            var serializer = new JsonPolicySerializer();

            var actual = serializer.GetPolicyFromJsonString(inputJson);
            var expected = new Policy();

            //Assert.Equal(expected.Type, actual.Type);
            AssertPoliciesEqual(expected, actual);
        }

        private void AssertPoliciesEqual(Policy expected, Policy actual)
        {
            Assert.Equal(expected.Type, actual.Type);

            #region Life
            Assert.Equal(expected.FullName, actual.FullName);
            Assert.Equal(expected.DateOfBirth, actual.DateOfBirth);
            Assert.Equal(expected.IsSmoker, actual.IsSmoker);
            Assert.Equal(expected.Amount, actual.Amount);
            #endregion

            #region Land
            Assert.Equal(expected.Address, actual.Address);
            Assert.Equal(expected.Size, actual.Size);
            Assert.Equal(expected.Valuation, actual.Valuation);
            Assert.Equal(expected.BondAmount, actual.BondAmount);
            #endregion

            #region Auto
            Assert.Equal(expected.Make, actual.Make);
            Assert.Equal(expected.Model, actual.Model);
            Assert.Equal(expected.Year, actual.Year);
            Assert.Equal(expected.Miles, actual.Miles);
            Assert.Equal(expected.Deductible, actual.Deductible);
            #endregion
        }
    }
}
