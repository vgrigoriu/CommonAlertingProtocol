using CAPNet.Models;
using Xunit;

namespace CAPNet
{
    public class CeilingExistenceValidatorTests
    {
        [Fact]
        public void AreaWithCeilingAndWitAltitudeNullIsInvalid()
        {
            var area = new Area();
            area.Ceiling = 123;
            area.Altitude = null;

            var ceilingExistanceValidator = new CeilingExistenceValidator(area);
            Assert.False(ceilingExistanceValidator.IsValid);
        }

        [Fact]
        public void AreaWithCeilingAndWitAltitudeIsValid()
        {
            var area = new Area();
            area.Ceiling = 123;
            area.Altitude = 142;

            var ceilingExistanceValidator = new CeilingExistenceValidator(area);
            Assert.True(ceilingExistanceValidator.IsValid);
        }

        [Fact]
        public void AreaWithCeilingNullAndWithAltitudeNullIsValid()
        {
            var area = new Area();
            area.Ceiling = null;
            area.Altitude = null;

            var ceilingExistanceValidator = new CeilingExistenceValidator(area);
            Assert.True(ceilingExistanceValidator.IsValid);
        }
    }
}
