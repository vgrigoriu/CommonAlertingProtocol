using CAPNet.Models;
using Xunit;

namespace CAPNet
{
    public class DigestValidatorTests
    {
        [Fact]
        public void ResourceWithDigestNullIsValid()
        {
            var resource = new Resource();
            resource.Digest = null;

            var digestValidator = new DigestValidator(resource);
            Assert.True(digestValidator.IsValid);
        }

        [Fact]
        public void ResourceWithInvalidDigestIsInvalid()
        {
            var resource = new Resource();
            resource.Digest = "da39a3ee5e6b4b";

            var digestValidator = new DigestValidator(resource);
            Assert.False(digestValidator.IsValid);
        }

        [Fact]
        public void ResourceWithValidDigestIsValid()
        {
            var resource = new Resource();
            resource.Digest = "2fd4e1c67a2d28fced849ee1bb76e7391b93eb12";

            var digestValidator = new DigestValidator(resource);
            Assert.True(digestValidator.IsValid);
        }
    }
}
