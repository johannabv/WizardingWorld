using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade {
    [TestClass] public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<CharacterView, Character, CharacterData>, object> {
        private class TestClass : BaseViewFactory<CharacterView, Character, CharacterData> {
            protected override Character ToEntity(CharacterData d) => new(d);
        }
        protected override BaseViewFactory<CharacterView, Character, CharacterData> CreateObj() => new TestClass();
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            dynamic? v = GetRandom.Value<CharacterView>();
            dynamic? o = obj.Create(v);
            ArePropertiesEqual(v, o.Data);
        }
        [TestMethod] public void CreateObjectTest() {
            dynamic? d = GetRandom.Value<CharacterData>();
            CharacterView v = obj.Create(new Character(d));
            ArePropertiesEqual(d, v);
        }
    }
}
