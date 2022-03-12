using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade {
    [TestClass] public class BaseViewFactoryTests : AbstractClassTests {
        private class TestClass : BaseViewFactory<SpellView, Spell, SpellData>
        {
            protected override Spell toEntity(SpellData d) => new Spell(d);
        }
        protected override object createObject() => new TestClass();
    }
}
