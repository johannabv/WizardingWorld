using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class AddressViewTests : SealedClassTests<AddressView, BaseView> {
        [TestMethod] public void StreetTest() => IsRequired<string?>("Street");
        [TestMethod] public void CityTest() => IsDisplayNamed<string?>("City");
        [TestMethod] public void RegionTest() => IsDisplayNamed<string?>("Region");
        [TestMethod] public void ZipCodeTest() => IsDisplayNamed<string?>("Zip code");
        [TestMethod] public void CountryIdTest() => IsDisplayNamed<string?>("Country");
        [TestMethod] public void DescriptionTest() => IsRequired<string?>("Description");
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full info");
    }

    [TestClass] public class AddressViewFactoryTests
        : ViewFactoryTests<AddressViewFactory, AddressView, Address, AddressData> {
        protected override Address ToObject(AddressData d) => new(d);
        [TestMethod] public override void CreateTest() { }
    }
}
