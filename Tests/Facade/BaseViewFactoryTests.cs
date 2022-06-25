using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade {
    [TestClass] public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<CharacterView, Character, CharacterData>, object> {
        private class TestClass : BaseViewFactory<CharacterView, Character, CharacterData> {
            protected override Character ToEntity(CharacterData d) => new(d);
        }
        protected override BaseViewFactory<CharacterView, Character, CharacterData> CreateObj() => new TestClass();
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            dynamic? expectedView = GetRandom.Value<CharacterView>();
            dynamic? actualView = Obj.Create(expectedView);
            ArePropertiesEqual(expectedView, actualView.Data);
        }
        [TestMethod] public void CreateObjectTest() {
            dynamic? expectedObject = GetRandom.Value<CharacterData>();
            CharacterView actualObject = Obj.Create(new Character(expectedObject));
            ArePropertiesEqual(expectedObject, actualObject);
        }
    }
}
