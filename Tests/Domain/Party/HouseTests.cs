using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class HouseTests : SealedClassTests<House, BaseEntity<HouseData>> {
        protected override House CreateObj() => new(GetRandom.Value<HouseData>());
        [TestMethod] public void HouseNameTest() => IsReadOnly(obj.Data.HouseName);
        [TestMethod] public void FounderNameTest() => IsReadOnly(obj.Data.FounderName);
        [TestMethod] public void HeadOfHouseNameTest() => IsReadOnly(obj.Data.HeadOfHouseName);
        [TestMethod] public void ColorTest() => IsReadOnly(obj.Data.Color);
        [TestMethod] public void DescriptionTest() => IsReadOnly(obj.Data.Description);
        [TestMethod] public void ToStringTest() {
            var expected = $"{obj.HouseName} ({obj.Color}), {obj.Description}";
            AreEqual(expected, obj.ToString());
        }
        [TestMethod] public void CharactersTest() => TestList<ICharactersRepo, Character, CharacterData>(
                d => d.HogwartsHouse = obj.HouseName, d => new Character(d), () => obj.Characters);
    }
}
