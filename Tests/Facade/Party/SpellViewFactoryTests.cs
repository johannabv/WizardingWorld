using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class SpellViewFactoryTests : SealedClassTests<SpellViewFactoryTests>{
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var d = new SpellData() {
                ID = "id",
                SpellName = "spell",
                Description = "something",
                Type = "Slytherin"
            };
            var e = new Spell(d);
            var v = new SpellViewFactory().Create(e);
            IsNotNull(v);
            AreEqual(v.ID, e.ID);
            AreEqual(v.SpellName, e.SpellName);
            AreEqual(v.Description, e.Description);
            AreEqual(v.Type, e.Type);
            AreEqual(v.FullName, e.ToString());
        }
        [TestMethod] public void CreateEntityTest() {
            var v = new SpellView() {
                ID = "id",
                SpellName = "spell",
                Description = "something",
                Type = "Slytherin"
            };
            var e = new SpellViewFactory().Create(v);
            IsNotNull(e);
            AreEqual(e.ID, v.ID);
            AreEqual(e.SpellName, v.SpellName);
            AreEqual(e.Description, v.Description);
            AreEqual(e.Type, v.Type);
            AreNotEqual(e.ToString(), v.FullName);
        }
    }
}
