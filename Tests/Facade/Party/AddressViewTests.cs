using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class AddressViewTests : SealedClassTests<AddressView, BaseView> {
        [TestMethod] public void StreetTest() => IsRequired<string?>("Street");
        [TestMethod] public void CityTest() => IsDisplayNamed<string?>("City");
        [TestMethod] public void RegionTest() => IsDisplayNamed<string?>("Region");
        [TestMethod] public void ZipCodeTest() => IsDisplayNamed<string?>("Zip code");
        [TestMethod] public void CountryIDTest() => IsDisplayNamed<string?>("Country");
        [TestMethod] public void DescriptionTest() => IsRequired<string?>("Description");
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full info");
    }

}
