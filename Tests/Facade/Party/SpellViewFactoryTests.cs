using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class SpellViewFactoryTests : SealedClassTests<SpellViewFactory>{
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<SpellData>();
            var e = new Spell(d);
            var v = new SpellViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.ID, e.ID);
            areEqual(v.SpellName, e.SpellName);
            areEqual(v.Description, e.Description);
            areEqual(v.Type, e.Type);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<SpellView>();
            var e = new SpellViewFactory().Create(v);
            isNotNull(e);
            areEqual(e.ID, v.ID);
            areEqual(e.SpellName, v.SpellName);
            areEqual(e.Description, v.Description);
            areEqual(e.Type, v.Type);
            areNotEqual(e.ToString(), v.FullName);
        }
    }
}
