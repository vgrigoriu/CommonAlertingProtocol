using CAPNet.Models;
using Xunit;

namespace CAPNet
{
    public class ParameterValidatorTests
    {
        [Fact]
        public void ParameterWithNullValueAndValueNameIsInvalid()
        {
            string valueName = "HSAS";
            string value = null;
            var parameter = new Parameter(valueName, value);

            var parameterValidator = new ParameterValidator(parameter);
            Assert.False(parameterValidator.IsValid);
        }

        [Fact]
        public void ParameterWithValueAndValueNameIsValid()
        {
            string valueName = "HSAS";
            string value = "00512";
            var parameter = new Parameter(valueName, value);

            var parameterValidator = new ParameterValidator(parameter);
            Assert.True(parameterValidator.IsValid);
        }
    }
}
