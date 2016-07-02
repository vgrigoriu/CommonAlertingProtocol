using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class MimeTypeValidatorTests
    {
        [Fact]
        public void MimeTypeWithValidTopLevelIsValid()
        {
            var resource = new Resource();
            resource.MimeType = "image/jpeg";

            var mimeTypeValidator = new MimeTypeValidator(resource);
            Assert.True(mimeTypeValidator.IsValid);
        }

        [Fact]
        public void MimeTypeWithInvalidTopLevelIsInvalid()
        {
            var resource = new Resource();
            resource.MimeType = "invalidMimeType";

            var mimeTypeValidator = new MimeTypeValidator(resource);
            Assert.False(mimeTypeValidator.IsValid);
        }
    }
}
