using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CharacterTests : SealedClassTests<CharacterData> {
        [TestMethod] public void FirstNameTest() => IsInconclusive();
        [TestMethod] public void LastNameTest() => IsInconclusive();
        [TestMethod] public void OrganisationTest() => IsInconclusive();
        [TestMethod] public void HogwartsHouseTest() => IsInconclusive();
        [TestMethod] public void GenderTest() => IsInconclusive();
        [TestMethod] public void DoBTest() => IsInconclusive();
        [TestMethod] public void ToStringTest() => IsInconclusive();
        [TestMethod] public void CharacterAddressesTest() => IsInconclusive();
        [TestMethod] public void AddressesTest() => IsInconclusive();

    }
}
