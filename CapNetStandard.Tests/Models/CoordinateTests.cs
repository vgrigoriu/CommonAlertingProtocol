using System.Globalization;
using System.Threading;
using CAPNet.Models;
using Xunit;

namespace CAPNet.Tests.Models
{
    public class CoordinateTests
    {
        [Fact]
        public void CoordinatesAreParsedCorrectlyInRomanianLocale()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ro-RO");

            var coordinate = new Coordinate("38.47,-120.14");

            Assert.Equal(38.47m, coordinate.Latitude);
        }
    }
}
