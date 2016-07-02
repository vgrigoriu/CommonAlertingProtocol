using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class CircleValidatorTests
    {
        [Fact]
        public void CircleWithInvalidCoordinatesIsInvalid()
        {
            var invalidCoordinate = new Coordinate(400, 400);
            var invalidCircle = new Circle(invalidCoordinate, 14);

            var circleValidator = new CircleValidator(invalidCircle);
            Assert.False(circleValidator.IsValid);

            var errors = from error in circleValidator.Errors
                         where error.GetType() == typeof(Wgs84Error)
                         select error;
            Assert.NotEmpty(errors);
        }

        [Fact]
        public void CircleWithValidCoordinatesIsValid()
        {
            var validCoordinate = new Coordinate(50, 50);
            var validCircle = new Circle(validCoordinate, 55);

            var circleValidator = new CircleValidator(validCircle);
            Assert.True(circleValidator.IsValid);
        }
    }
}
