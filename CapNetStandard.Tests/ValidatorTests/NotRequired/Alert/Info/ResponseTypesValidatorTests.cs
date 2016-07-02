using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class ResponseTypesValidatorTests
    {
        [Fact]
        public void ResponseTypesWithValidElementsIsValid()
        {
            var info = new Info();

            ResponseType firstResponseType = ResponseType.Assess;
            ResponseType secondeResponseType = ResponseType.Avoid;

            info.ResponseTypes.Add(firstResponseType);
            info.ResponseTypes.Add(secondeResponseType);

            var responseTypeValidator = new ResponseTypesValidator(info);
            Assert.True(responseTypeValidator.IsValid);
        }

        [Fact]
        public void ResponseTypesWithOneInvalidElementIsInvalid()
        {
            var info = new Info();

            //valid responseType
            ResponseType firstResponseType = ResponseType.Assess;
            //invalid responseType
            ResponseType secondeResponseType = (ResponseType)123;

            info.ResponseTypes.Add(firstResponseType);
            info.ResponseTypes.Add(secondeResponseType);

            var responseTypeValidator = new ResponseTypesValidator(info);
            Assert.False(responseTypeValidator.IsValid);

            var responseTypesErrors = from error in responseTypeValidator.Errors
                                      where error.GetType() == typeof(ResponseTypeError)
                                      select error;
            Assert.NotEmpty(responseTypesErrors);
        }
    }
}
