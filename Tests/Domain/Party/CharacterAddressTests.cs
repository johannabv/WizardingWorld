using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CharacterAddressTests : SealedClassTests<CharacterAddress, BaseEntity<CharacterAddressData>> {
        protected override CharacterAddress CreateObj() => new(GetRandom.Value<CharacterAddressData>());
        [TestMethod] public void CharacterIDTest() => IsReadOnly(obj.Data.CharacterID);
        [TestMethod] public void AddressIDTest() => IsReadOnly(obj.Data.AddressID);
        [TestMethod] public void CharacterTest() => IsInconclusive();
        [TestMethod] public void AddressTest() => IsInconclusive();
        [TestMethod] public void UseForTest() => IsReadOnly(obj.Data.UseFor);
    }
}
