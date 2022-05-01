using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;
using WizardingWorld.Tests.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CharacterAddressViewFactoryTests
        : ViewFactoryTests<CharacterAddressViewFactory, CharacterAddressView, CharacterAddress, CharacterAddressData> {
        protected override CharacterAddress ToObject(CharacterAddressData d) => new(d);
    }
}
