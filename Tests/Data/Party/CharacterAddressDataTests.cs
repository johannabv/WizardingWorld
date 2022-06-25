using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data;
using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class CharacterAddressDataTests : SealedClassTests<CharacterAddressData, BaseData> {
        [TestMethod] public void CharacterIdTest() => IsProperty<string>();
        [TestMethod] public void AddressIdTest() => IsProperty<string?>();
        [TestMethod] public void UseForTest() => IsProperty<AddressUse?>();
    }
}
