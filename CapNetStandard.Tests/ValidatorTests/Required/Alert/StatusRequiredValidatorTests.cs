using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class StatusRequiredValidatorTests
    {
        [Fact]
        public void AlertWithStatusWellDefinedIsValid()
        {
            var alert = new Alert();
            alert.Status = Status.Draft;

            var statusRequiredValidator = new StatusRequiredValidator(alert);
            Assert.True(statusRequiredValidator.IsValid);
        }

        [Fact]
        public void AlertWithStatusWrongDefinedIsInvalid()
        {
            var alert = new Alert();
            alert.Status = (Status)123;

            var statusRequiredValidator = new StatusRequiredValidator(alert);
            Assert.False(statusRequiredValidator.IsValid);
            Assert.Equal(typeof(StatusRequiredError), statusRequiredValidator.Errors.ElementAt(0).GetType());
        }
    }
}
