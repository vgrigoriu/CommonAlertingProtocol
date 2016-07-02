using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class LanguageValidatorTests
    {
        [Fact]
        public void InfoWithValidLanguageIsValid()
        {
            var info = new Info();
            info.Language = "en-us";

            var languageValidator = new LanguageValidator(info);
            Assert.True(languageValidator.IsValid);
        }

        [Fact]
        public void InfoWithInvalidLanguageIsIvalid()
        {
            var info = new Info();
            info.Language = "en-uss";

            var languageValidator = new LanguageValidator(info);
            Assert.False(languageValidator.IsValid);
        }
    }
}
