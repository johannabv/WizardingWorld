using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class CharacterAddressViewTests : SealedClassTests<CharacterAddressView, BaseView> {
        [TestMethod] public void CharacterIdTest() => IsRequired<string?>("Character");
        [TestMethod] public void AddressIdTest() => IsRequired<string?>("Place");
        [TestMethod] public void UseForTest() => IsDisplayNamed<AddressUse?>("Use for");
    }
    [TestClass] public class CharacterAddressViewFactoryTests
        : ViewFactoryTests<CharacterAddressViewFactory, CharacterAddressView, CharacterAddress, CharacterAddressData> {
        protected override CharacterAddress ToObject(CharacterAddressData d) => new(d);
    }
}
