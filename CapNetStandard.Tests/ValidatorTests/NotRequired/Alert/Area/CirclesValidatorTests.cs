using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class CirclesValidatorTests
    {
        [Fact]
        public void AreaWithCircleWithValidCoordinatesIsValid()
        {
            var invalidCoordinate = new Coordinate(400, 400);
            var invalidCircle = new Circle(invalidCoordinate, 14);
            var area = new Area();
            area.Circles.Add(invalidCircle);

            var circlesValidator = new CirclesValidator(area);
            Assert.False(circlesValidator.IsValid);

            var errors = from error in circlesValidator.Errors
                         where error.GetType() == typeof(Wgs84Error)
                         select error;
            Assert.NotEmpty(errors);
        }

        [Fact]
        public void AreaWithCircleWithInvalidCoordinatesIsInvalid()
        {
            var validCoordinate = new Coordinate(50, 50);
            var validCircle = new Circle(validCoordinate, 20);
            var area = new Area();
            area.Circles.Add(validCircle);

            var circlesValidator = new CirclesValidator(area);
            Assert.True(circlesValidator.IsValid);
        }
    }
}
