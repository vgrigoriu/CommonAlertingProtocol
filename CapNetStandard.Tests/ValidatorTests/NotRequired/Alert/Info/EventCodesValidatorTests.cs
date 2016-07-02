using CAPNet.Models;
using System.Linq;
using CAPNet.Validator.Errors;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class EventCodesValidatorTests
    {
        [Fact]
        public void InfoWithEventCodeThatHasValueNullAndValueNameIsInvalid()
        {
            var info = new Info();
            string valueName = "HSAS";
            string value = null;
            var eventCode = new EventCode(valueName, value);
            info.EventCodes.Add(eventCode);

            var eventCodesValidator = new EventCodesValidator(info);
            Assert.False(eventCodesValidator.IsValid);
            Assert.Equal(typeof(NamedValueError<EventCode>), eventCodesValidator.Errors.ElementAt(0).GetType());
        }

        [Fact]
        public void InfoWithEventCodeThatHasValueAndValueNameIsValid()
        {
            var info = new Info();
            string valueName = "HSAS";
            string value = "SVR";
            var eventCode = new EventCode(valueName, value);
            info.EventCodes.Add(eventCode);

            var eventCodesValidator = new EventCodesValidator(info);
            Assert.True(eventCodesValidator.IsValid);
        }
    }
}
