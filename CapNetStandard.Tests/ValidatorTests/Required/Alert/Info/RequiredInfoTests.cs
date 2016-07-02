using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class RequiredInfoTests
    {
        [Fact]
        public void OneInfoWithAllRequiredElementsIsValid()
        {
            var alert = new Alert();
            var info = InfoCreator.CreateValidInfo();

            // one info in alert
            alert.Info.Add(info);
            var singleAlertValidator = new InfoValidator(alert);
            var singleErrorsValidation = singleAlertValidator.Errors;
            // the info should be valid
            Assert.True(singleAlertValidator.IsValid);
            Assert.Equal(0, singleErrorsValidation.Count());
        }

        [Fact]
        public void OneInfoWithNoneOfTheRequiredElementsIsInvalid()
        {
            var alert = new Alert();

            // one info in alert
            alert.Info.Add(new Info());
            var alertValidatorSingle = new InfoValidator(alert);
            var validationErrorsSingle = alertValidatorSingle.Errors;
            // 5 errors detected >> missing subelements : Category , Certainty , Event , Severity , Urgency
            Assert.False(alertValidatorSingle.IsValid);
            Assert.Equal(5, validationErrorsSingle.Count());
        }

        [Fact]
        public void TwoInfosInAnAlertWithAllRequiredElementsAreValid()
        {
            var alert = new Alert();
            var info = InfoCreator.CreateValidInfo();

            // two infos in alert
            alert.Info.Add(info);
            alert.Info.Add(info);
            var doubleAlertValidator = new InfoValidator(alert);
            // the info should be valid
            Assert.True(doubleAlertValidator.IsValid);
            Assert.Equal(0, doubleAlertValidator.Errors.Count());
        }

        [Fact]
        public void TwoInfosInAnAlertWithNoneOfTheRequiredElementsAreInvalid()
        {
            var alert = new Alert();
            // two infos in alert
            alert.Info.Add(new Info());
            alert.Info.Add(new Info());
            var alertValidatorDouble = new InfoValidator(alert);
            var validationErrorsDouble = alertValidatorDouble.Errors;
            // 10 errors detected >> mising sublements x 2
            Assert.False(alertValidatorDouble.IsValid);
            Assert.Equal(10, validationErrorsDouble.Count());
        }
    }
}
