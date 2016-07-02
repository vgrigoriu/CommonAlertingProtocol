using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class GeoCodesValidatorTests
    {
        [Fact]
        public void GeoCodeWithNullValueIsInvalid()
        {
            var area = new Area();

            string value = null;
            string valueName = "HSAS";
            var geoCode = new GeoCode(valueName, value);
            area.GeoCodes.Add(geoCode);

            var geoCodesValidator = new GeoCodesValidator(area);
            Assert.False(geoCodesValidator.IsValid);
            //Assert.Equal(typeof(GeoCodeError), geoCodesValidator.Errors.ElementAt(0).GetType());
        }

        [Fact]
        public void GeoCodeWithValueAndValueNameIsValid()
        {
            var area = new Area();

            string value = "0123";
            string valueName = "HSAS";
            var geoCode = new GeoCode(valueName, value);
            area.GeoCodes.Add(geoCode);

            var geoCodesValidator = new GeoCodesValidator(area);
            Assert.True(geoCodesValidator.IsValid);
        }
    }
}
