using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class ResourceDescriptionRequiredValidatorTests
    {
        [Fact]
        public void ResourceWithEmptyDescriptionIsInvalid()
        {
            var resource = new Resource();
            resource.Description = "";

            var descriptionValidator = new ResourceDescriptionRequiredValidator(resource);
            Assert.False(descriptionValidator.IsValid);
            Assert.Equal(1, descriptionValidator.Errors.Count());
        }

        [Fact]
        public void ResourceWithDescriptionIsValid()
        {
            var resource = new Resource();
            resource.Description = "description";

            var descriptionValidator = new ResourceDescriptionRequiredValidator(resource);
            Assert.True(descriptionValidator.IsValid);
        }

    }
}
