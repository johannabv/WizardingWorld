using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Enums;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class CharacterAddressViewTests : SealedClassTests<CharacterAddressView, BaseView> {
        [TestMethod] public void CharacterIDTest() => IsRequired<string?>("Character");
        [TestMethod] public void AddressIDTest() => IsRequired<string?>("Place");
        [TestMethod] public void UseForTest() => IsDisplayNamed<AddressUse?>("Use for");
    }
}
