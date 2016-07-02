using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class HeadlineValidatorTests
    {
        [Fact]
        public void InfoWithHeadlineLongerThan160CharactersIsInvalid()
        {
            var info = new Info();
            info.Headline = "SEVERE THUNDERSTORM WARNING SEVERE THUNDERSTORM WARNING SEVERE THUNDERSTORM WARNING SEVERE THUNDERSTORM WARNING SEVERE THUNDERSTORM WARNING SEVERE THUNDERSTORM WARNING SEVERE THUNDERSTORM WARNING SEVERE THUNDERSTORM WARNING SEVERE THUNDERSTORM WARNING ";
            
            var headlineValidator = new HeadlineValidator(info);
            Assert.False(headlineValidator.IsValid);
            Assert.Equal(typeof(HeadlineError), headlineValidator.Errors.ElementAt(0).GetType());
        }

        [Fact]
        public void InfoWithHeadlineLessThan160CharactersIsValid()
        {
            var info = new Info();
            info.Headline = "SEVERE THUNDERSTORM WARNING ";
            
            var headlineValidator = new HeadlineValidator(info);
            Assert.True(headlineValidator.IsValid);
        }
    }
}
