using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data;
using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class CharacterAddressDataTests : SealedClassTests<CharacterAddressData, BaseData> {
        [TestMethod] public void CharacterIDTest() => IsProperty<string>();
        [TestMethod] public void AddressIDTest() => IsProperty<string?>();
        [TestMethod] public void UseForTest() => IsProperty<AddressUse?>();
    }
}
