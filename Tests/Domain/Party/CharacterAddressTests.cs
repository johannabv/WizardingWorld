using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CharacterAddressTests : SealedClassTests<CharacterAddressData> {
        [TestMethod] public void CharacterIDTest() => IsInconclusive();
        [TestMethod] public void AddressIDTest() => IsInconclusive();
        [TestMethod] public void CharacterTest() => IsInconclusive();
        [TestMethod] public void AddressTest() => IsInconclusive();
        [TestMethod] public void UseForTest() => IsInconclusive();
    }
}
