using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class AddressTests : SealedClassTests<AddressData> {
        [TestMethod] public void StreetTest() => IsInconclusive();
        [TestMethod] public void CityTest() => IsInconclusive();
        [TestMethod] public void RegionTest() => IsInconclusive();
        [TestMethod] public void ZipCodeTest() => IsInconclusive();
        [TestMethod] public void DescriptionTest() => IsInconclusive();
        [TestMethod] public void CountryIDTest() => IsInconclusive();
        [TestMethod] public void ToStringTest() => IsInconclusive();
        [TestMethod] public void CharacterAddressesTest() => IsInconclusive();
        [TestMethod] public void CharactersTest() => IsInconclusive();
        
    }
}
