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
            isNotNull(v);
            areEqual(v.ID, e.ID);
            areEqual(v.DoB, e.DoB);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.Gender, e.Gender);
            areEqual(v.HogwartsHouse, e.HogwartsHouse);
            areEqual(v.Organisation, e.Organisation);
            areEqual(v.FullInfo, e.ToString()); 
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
            isNotNull(e);
            areEqual(e.ID, v.ID);
            areEqual(e.DoB, v.DoB);
            areEqual(e.FirstName, v.FirstName);
            areEqual(e.LastName, v.LastName);
            areEqual(e.Gender, v.Gender);
            areEqual(e.HogwartsHouse, v.HogwartsHouse);
            areEqual(e.Organisation, v.Organisation);
            areNotEqual(e.ToString(), v.FullInfo);
        }
    }
}
