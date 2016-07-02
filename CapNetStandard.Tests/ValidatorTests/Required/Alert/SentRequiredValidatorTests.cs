using CAPNet.Models;
using System;
using Xunit;

namespace CAPNet
{
    public class SentRequiredValidatorTests
    {
        [Fact]
        public void AlertWithSentIsValid()
        {
            var alert = new Alert();
            alert.Sent = new DateTimeOffset(2008, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0));

            var sentRequiredValidator = new SentRequiredValidator(alert);
            Assert.True(sentRequiredValidator.IsValid);
        }

        [Fact]
        public void AlertWithoutSentIsInvalid()
        {
            var alert = new Alert();
            alert.Sent = null;

            var sentRequiredValidator = new SentRequiredValidator(alert);
            Assert.False(sentRequiredValidator.IsValid);
        }
    }
}
