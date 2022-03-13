using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CharacterViewFactoryTests : SealedClassTests<CharacterViewFactory> {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var d = new CharacterData() {
                ID = "id",
                FirstName = "Mari",
                LastName = "Maasikas",
                Gender = true,
                DoB = System.DateTime.Now,
                HogwartsHouse = "Slytherin",
                Organisation = "Order"
            };
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
            AreEqual(v.FullInfo, e.ToString()); 
        }
        [TestMethod] public void CreateEntityTest() {
            var v = new CharacterView() {
                ID = "id",
                FirstName = "Mari",
                LastName = "Maasikas",
                Gender = true,
                DoB = System.DateTime.Now,
                HogwartsHouse = "Slytherin",
                Organisation = "Order",
                FullInfo="name"
            };
            var e = new CharacterViewFactory().Create(v);
            IsNotNull(e);
            AreEqual(e.ID, v.ID);
            AreEqual(e.DoB, v.DoB);
            AreEqual(e.FirstName, v.FirstName);
            AreEqual(e.LastName, v.LastName);
            AreEqual(e.Gender, v.Gender);
            AreEqual(e.HogwartsHouse, v.HogwartsHouse);
            AreEqual(e.Organisation, v.Organisation);
            AreNotEqual(e.ToString(), v.FullInfo);
        }
    }
}
