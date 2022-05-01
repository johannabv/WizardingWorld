using Microsoft.VisualStudio.TestTools.UnitTesting; 
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party; 
using WizardingWorld.Facade.Party;
using WizardingWorld.Tests.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class SpellViewFactoryTests
        : ViewFactoryTests<SpellViewFactory, SpellView, Spell, SpellData> {
        protected override Spell ToObject(SpellData d) => new(d);
    }
}
