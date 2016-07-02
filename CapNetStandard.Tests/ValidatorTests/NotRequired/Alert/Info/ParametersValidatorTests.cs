using CAPNet.Models;
using Xunit;
using System.Linq;
using CAPNet.Validator.Errors;

namespace CAPNet.Tests.ValidatorTests
{
    public class ParametersValidatorTests
    {
        [Fact]
        public void InfoWithParametersWithValueAndValueNameNullIsInvalid()
        {
            var info = new Info();
            var value = "13123";
            string valueName = null;
            var parameter = new Parameter(valueName, value);
            info.Parameters.Add(parameter);

            var parametersValidator = new ParametersValidator(info);
            Assert.False(parametersValidator.IsValid);
            Assert.Equal(typeof(NamedValueError<Parameter>), parametersValidator.Errors.ElementAt(0).GetType());
        }

        [Fact]
        public void InfoWithParametersWithValueAndValueNameIsValid()
        {
            var info = new Info();
            var value = "123";
            var valueName = "HSAS";
            var parameter = new Parameter(valueName, value);
            info.Parameters.Add(parameter);

            var parametersValidator = new ParametersValidator(info);
            Assert.True(parametersValidator.IsValid);
        }

        [Fact]
        public void InfoWithNoParametersInTheListIsValid()
        {
            var info = new Info();

            var parametersValidator = new ParametersValidator(info);
            Assert.True(parametersValidator.IsValid);
        }
    }
}
