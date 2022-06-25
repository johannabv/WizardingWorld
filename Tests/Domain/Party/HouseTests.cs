using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class HouseTests : SealedClassTests<House, BaseEntity<HouseData>> {
        protected override House CreateObj() => new(GetRandom.Value<HouseData>());
        [TestMethod] public void HouseNameTest() => IsReadOnly(Obj.Data.HouseName);
        [TestMethod] public void FounderNameTest() => IsReadOnly(Obj.Data.FounderName);
        [TestMethod] public void HeadOfHouseNameTest() => IsReadOnly(Obj.Data.HeadOfHouseName);
        [TestMethod] public void ColorTest() => IsReadOnly(Obj.Data.Color);
        [TestMethod] public void DescriptionTest() => IsReadOnly(Obj.Data.Description);
        [TestMethod] public void ToStringTest() {
            string expected = $"{Obj.HouseName} ({Obj.Color}), {Obj.Description}";
            AreEqual(expected, Obj.ToString());
        }
        [TestMethod] public void CharactersTest() => TestList<ICharactersRepo, Character, CharacterData>(
                d => d.HogwartsHouse = Obj.HouseName, d => new Character(d), () => Obj.Characters.Value);
    }
}
