using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class SpellViewTests : SealedClassTests<SpellView, BaseView>{
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void SpellNameTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
        [TestMethod] public void TypeTest() => IsProperty<string?>();
    }
    [TestClass] public class SpellViewFactoryTests
        : ViewFactoryTests<SpellViewFactory, SpellView, Spell, SpellData> {
        protected override Spell ToObject(SpellData d) => new(d);
    }
}
