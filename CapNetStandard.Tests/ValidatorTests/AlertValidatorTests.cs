using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class AlertValidatorTests
    {
        [Fact]
        public void GeneralAlertWithAllRequiredFieldsIsValid()
        {
            var alert = new Alert();
            alert.Identifier = "KSTO1055887203";
            alert.Sender = "Sender";
            alert.Status = Status.Draft;
            alert.MessageType = MessageType.Error;
            alert.Note = "DescriptiveError";
            alert.Scope = Scope.Restricted;
            alert.Restriction = "Draft";
            alert.Sent = new System.DateTimeOffset();

            var info = new Info();
            var category = Category.Fire;
            //Category required
            info.Categories.Add(category);
            //Certainty required
            info.Certainty = Certainty.Observed;
            //EventRequired
            info.Event = "ImportantEvent";
            //SeverityRequired
            info.Severity = Severity.Minor;
            //UrgencyRequired
            info.Urgency = Urgency.Future;
            alert.Info.Add(info);

            var alertValidator = new AlertValidator(alert);
            Assert.True(alertValidator.IsValid);
        }

        [Fact]
        public void GeneralAlertWithWrongCategoryInInfoIsInvalid()
        {
            var alert = new Alert();
            alert.Identifier = "KSTO1055887203";
            alert.Sender = "Sender";
            alert.Status = Status.Draft;
            alert.MessageType = MessageType.Error;
            alert.Note = "DescriptiveError";
            alert.Scope = Scope.Restricted;
            alert.Restriction = "Draft";
            alert.Sent = new System.DateTimeOffset();

            var info = new Info();
            //invalid category set : 
            var category = (Category)123;
            //Category required
            info.Categories.Add(category);
            //Certainty required
            info.Certainty = Certainty.Observed;
            //EventRequired
            info.Event = "ImportantEvent";
            //SeverityRequired
            info.Severity = Severity.Minor;
            //UrgencyRequired
            info.Urgency = Urgency.Future;
            alert.Info.Add(info);

            var alertValidator = new AlertValidator(alert);
            Assert.False(alertValidator.IsValid);
            var categoryErrors = from error in alertValidator.Errors
                                 where typeof(InvalidCategoryError) == error.GetType()
                                 select error;
            Assert.NotEmpty(categoryErrors);
        }

        [Fact]
        public void GeneralAlertWithNoCategoryAndCertaintyWrongSetAndSentNullIsInvalid()
        {
            var alert = new Alert();
            alert.Identifier = "KSTO1055887203";
            alert.Sender = "Sender";
            alert.Status = Status.Draft;
            alert.MessageType = MessageType.Error;
            alert.Note = "DescriptiveError";
            alert.Scope = Scope.Restricted;
            alert.Restriction = "Draft";
            alert.Sent = null;

            var info = new Info();
            //info.Categories Is Empty
            //Certainty is not well set;
            info.Certainty = (Certainty)123;
            //Event is also required
            info.Event = "Important Event";
            //Severity Required
            info.Severity = Severity.Minor;
            //Urgency Required
            info.Urgency = Urgency.Future;

            alert.Info.Add(info);

            var alertValidator = new AlertValidator(alert);
            Assert.False(alertValidator.IsValid);

            var categoryRequiredErrors = from error in alertValidator.Errors
                                         where typeof(CategoryRequiredError) == error.GetType()
                                         select error;
            Assert.NotEmpty(categoryRequiredErrors);

            var certaintyRequiredErrors = from error in alertValidator.Errors
                                          where typeof(CertaintyRequiredError) == error.GetType()
                                          select error;
            Assert.NotEmpty(certaintyRequiredErrors);

            var sentRequiredErrors = from error in alertValidator.Errors
                             where typeof(SentRequiredError) == error.GetType()
                             select error;
            Assert.NotEmpty(sentRequiredErrors);
        }
    }
}
