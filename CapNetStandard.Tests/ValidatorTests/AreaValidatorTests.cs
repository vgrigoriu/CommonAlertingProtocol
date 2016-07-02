using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class AreaValidatorTests
    {
        [Fact]
        public void AreaWithDescriptionIsValid()
        {
            var info = new Info();
            var area = new Area();
            area.Description = "U.S. nationwide and interests worldwide";
            info.Areas.Add(area);

            var areaValidator = new AreaValidator(info);
            Assert.True(areaValidator.IsValid);
        }

        [Fact]
        public void AreaWithOneDescriptionEmptyIsInvalid()
        {
            var info = new Info();
            var firstArea = new Area();
            firstArea.Description = "U.S. nationwide and interests worldwide";
            var secondArea = new Area();
            secondArea.Description = "";
            info.Areas.Add(firstArea);
            info.Areas.Add(secondArea);

            var areaValidator = new AreaValidator(info);
            Assert.False(areaValidator.IsValid);

            var emptyDescriptionErrors = from error in areaValidator.Errors
                                         where error.GetType() == typeof(AreaDescriptionRequiredError)
                                         select error;
            Assert.NotEmpty(emptyDescriptionErrors);
        }

        [Fact]
        public void AreaWithDescriptionAndCeilingAndAltitudeNullIsInvalid()
        {
            var info = new Info();
            var area = new Area();
            area.Description = "U.S. nationwide and interests worldwide";
            area.Ceiling = 123;
            area.Altitude = null;
            info.Areas.Add(area);

            var areaValidator = new AreaValidator(info);
            Assert.False(areaValidator.IsValid);

            var ceilingExistanceErrors = from error in areaValidator.Errors
                                         where error.GetType() == typeof(CeilingExistenceError)
                                         select error;
            Assert.NotEmpty(ceilingExistanceErrors);
        }

        [Fact]
        public void AreaWithDescriptionAndCeilingNullAndAltitudeNullIsValid()
        {
            var info = new Info();
            var area = new Area();
            area.Description = "U.S. nationwide and interests worldwide";
            area.Ceiling = null;
            area.Altitude = null;
            info.Areas.Add(area);

            var areaValidator = new AreaValidator(info);
            Assert.True(areaValidator.IsValid);
        }

        [Fact]
        public void AreaWith4CoordinatePairsAndFirstAndLastPairEqualIsValid()
        {
            var info = new Info();
            var area = new Area();
            area.Description = "U.S. nationwide and interests worldwide";
            var polygon = new Polygon("68.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14");
            area.Polygons.Add(polygon);
            info.Areas.Add(area);

            var areaValidator = new AreaValidator(info);
            Assert.False(areaValidator.IsValid);
            var polygonsErrors = from error in areaValidator.Errors
                                 where error.GetType() == typeof(PolygonWithFirstCoordinatePairEqualToLastCoordinatePairError)
                                 select error;
            Assert.NotEmpty(polygonsErrors);
        }

        [Fact]
        public void AreaWith3CoordinatePairsAndFirstAndLastPairEqualIsInvalid()
        {
            var info = new Info();
            var area = new Area();
            area.Description = "U.S. nationwide and interests worldwide";
            var polygon = new Polygon("38.47,-120.14 38.62,-119.89 38.47,-120.14");
            area.Polygons.Add(polygon);
            info.Areas.Add(area);

            var areaValidator = new AreaValidator(info);
            Assert.False(areaValidator.IsValid);
            var polygonsErrors = from error in areaValidator.Errors
                                 where error.GetType() == typeof(PolygonMinCoordinatesError)
                                 select error;
            Assert.NotEmpty(polygonsErrors);
        }
    }
}
