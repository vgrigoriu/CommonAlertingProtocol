using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class PolygonCoordinatesValidatorTests
    {
        [Fact]
        public void PolygonWithValidCoordinatesPairsIsValid()
        {
            var polygon = new Polygon("38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14");

            var polygonCoordinatesValidator = new PolygonCoordinatesValidator(polygon);
            Assert.True(polygonCoordinatesValidator.IsValid);
        }

        [Fact]
        public void PolygonWithOneInvalidCoordinatePairsIsInvalid()
        {
            var polygon = new Polygon("400,400 120,500");

            var polygonCoordinatesValidator = new PolygonCoordinatesValidator(polygon);
            Assert.False(polygonCoordinatesValidator.IsValid);
            Assert.Equal(typeof(Wgs84Error),polygonCoordinatesValidator.Errors.ElementAt(0).GetType());
        }
    }
}
