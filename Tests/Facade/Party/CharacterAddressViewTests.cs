using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Enums;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CharacterAddressViewTests : SealedClassTests<CharacterAddressView, BaseView> {
        [TestMethod] public void CharacterIDTest() => IsRequired<string?>("Character");
        [TestMethod] public void AddressIDTest() => IsRequired<string?>("Place");
        [TestMethod] public void UseForTest() => IsDisplayNamed<AddressUse?>("Use for");
    }
}
