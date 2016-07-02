using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class RequiredSeverityTests
    {
        [Fact]
        public void ValidRequiredSeverity()
        {
            var info = InfoCreator.CreateValidInfo();
            var severityValidator = new SeverityRequiredValidator(info);
            Assert.True(severityValidator.IsValid);
            Assert.Equal(0, severityValidator.Errors.Count());
        }

        [Fact]
        public void InvalidRequiredSeverity()
        {
            var severityValidator = new SeverityRequiredValidator(new Info());
            Assert.False(severityValidator.IsValid);
            Assert.Equal(1, severityValidator.Errors.Count());
        }
    }
}
