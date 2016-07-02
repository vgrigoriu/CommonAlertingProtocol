using CAPNet.Models;
using Xunit;

namespace CAPNet
{
    public class GeoCodeValidatorTests
    {
        [Fact]
        public void GeoCodeWithNullValueIsInvalid()
        {
            string value = null;
            string valueName = "HSAS";
            var geoCode = new GeoCode(valueName,value);
            
            var geoCodeValidator = new GeoCodeValidator(geoCode);
            Assert.False(geoCodeValidator.IsValid);
        }

        [Fact]
        public void GeoCodeWithValueAndValueNameIsValid()
        {
            string value = "0123";
            string valueName = "HSAS";
            var geoCode = new GeoCode(valueName, value);

            var geoCodeValidator = new GeoCodeValidator(geoCode);
            Assert.True(geoCodeValidator.IsValid);
        }
    }
}
