using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CharacterViewFactoryTests : SealedClassTests<CharacterViewFactory, BaseViewFactory<CharacterView, Character, CharacterData>> {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<CharacterData>();
            var e = new Character(d);
            var v = new CharacterViewFactory().Create(e);
            IsNotNull(v);
            AreEqual(v.ID, e.ID);
            AreEqual(v.DoB, e.DoB);
            AreEqual(v.FirstName, e.FirstName);
            AreEqual(v.LastName, e.LastName);
            AreEqual(v.Gender, e.Gender);
            AreEqual(v.HogwartsHouse, e.HogwartsHouse);
            AreEqual(v.Organisation, e.Organisation);
            AreEqual(v.FullName, e.ToString()); 
        }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<CharacterView>() as CharacterView;
            var e = new CharacterViewFactory().Create(v);
            IsNotNull(e);
            IsNotNull(v);
            ArePropertiesEqual(e, v);
            AreNotEqual(e.ToString(), v?.FullName);
        }
        
    }
}
