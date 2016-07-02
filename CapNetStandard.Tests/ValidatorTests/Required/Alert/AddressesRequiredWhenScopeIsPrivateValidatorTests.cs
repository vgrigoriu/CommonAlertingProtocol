using CAPNet.Models;
using Xunit;

namespace CAPNet
{
    public class AddressesRequiredWhenScopeIsPrivateValidatorTests
    {
        [Fact]
        public void AlertWithAddressAndNoScopeIsValid()
        {
            var alert = new Alert();
            alert.Addresses.Add("list1");
            alert.Addresses.Add("list2");
            alert.Addresses.Add("list3");

            var addressesRequiredWhenScopeValidator = new AddressesRequiredWhenScopePrivateValidator(alert);
            Assert.True(addressesRequiredWhenScopeValidator.IsValid);
        }

        [Fact]
        public void AlertWithAddressesAndScopePrivateIsValid()
        {
            var alert = new Alert();
            alert.Addresses.Add("list1");
            alert.Addresses.Add("list2");
            alert.Addresses.Add("list3");
            alert.Scope = Scope.Private;

            var addressesRequiredWhenScopeValidator = new AddressesRequiredWhenScopePrivateValidator(alert);
            Assert.True(addressesRequiredWhenScopeValidator.IsValid);
        }

        [Fact]
        public void AlertWithAddressesAndScopeNoPrivateIsValid()
        {
            var alert = new Alert();
            alert.Addresses.Add("list1");
            alert.Addresses.Add("list2");
            alert.Addresses.Add("list3");
            alert.Scope = Scope.Public;

            var addressesRequiredWhenScopeValidator = new AddressesRequiredWhenScopePrivateValidator(alert);
            Assert.True(addressesRequiredWhenScopeValidator.IsValid);
        }

        [Fact]
        public void AlertWithEmptyAddressesAndScopePrivateIsInvalid()
        {
            var alert = new Alert();
            alert.Scope = Scope.Private;

            var addressesRequiredWhenScopeValidator = new AddressesRequiredWhenScopePrivateValidator(alert);
            Assert.False(addressesRequiredWhenScopeValidator.IsValid);
        }
    }
}
