using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class ResourceValidatorTests
    {
        [Fact]
        public void ResourceWithUriAndNoSizeIsInvalid()
        {
            var info = new Info();
            var resource = new Resource();
            resource.Uri = new System.Uri("http://www.google.ro");
            resource.Size = null;
            info.Resources.Add(resource);

            var resourceValidator = new ResourceValidator(info);
            Assert.False(resourceValidator.IsValid);

            var sizeErrors = from error in resourceValidator.Errors
                             where error.GetType() == typeof(SizeRequiredError)
                             select error;
            Assert.NotEmpty(sizeErrors);
        }

        [Fact]
        public void ResourceWithDescriptionAndMimeTypeIsValid()
        {
            var info = CreateInfoWithResourceWithDescriptionAndMimeType("Description", "image/jpeg");

            var resourceValidator = new ResourceValidator(info);
            Assert.True(resourceValidator.IsValid);
            Assert.Equal(0, resourceValidator.Errors.Count());
        }

        [Fact]
        public void ResourceWithNoMimeTypeIsInvalid()
        {
            var alert = CreateInfoWithResourceWithDescriptionAndMimeType("Description", null);

            var resourceValidator = new ResourceValidator(alert);
            Assert.False(resourceValidator.IsValid);
        }

        [Fact]
        public void ResourceWithoutMimeTypeAndDescriptionHasTwoErrors()
        {
            var alert = CreateInfoWithResourceWithDescriptionAndMimeType(null, null);

            var resourceValidator = new ResourceValidator(alert);
            Assert.False(resourceValidator.IsValid);
        }

        private static Info CreateInfoWithResourceWithDescriptionAndMimeType(string description, string mimeType)
        {
            var info = new Info();
            var resource = new Resource();
            resource.Description = description;
            resource.MimeType = mimeType;
            info.Resources.Add(resource);

            return info;
        }
    }
}
