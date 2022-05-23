using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class SpellViewFactoryTests
        : ViewFactoryTests<SpellViewFactory, SpellView, Spell, SpellData> {
        protected override Spell ToObject(SpellData d) => new(d);
    }
}
