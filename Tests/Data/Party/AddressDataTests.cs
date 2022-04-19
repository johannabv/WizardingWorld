using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class AddressDataTests : SealedClassTests<AddressData> {
        [TestMethod] public void StreetTest() => IsProperty<string?>();
        [TestMethod] public void CityTest() => IsProperty<string?>();
        [TestMethod] public void RegionTest() => IsProperty<string?>();
        [TestMethod] public void ZipCodeTest() => IsProperty<string?>();
        [TestMethod] public void CountryIDTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
    }
}
