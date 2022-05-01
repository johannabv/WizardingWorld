using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CharacterTests : SealedClassTests<Character, BaseEntity<CharacterData>> {
        protected override Character CreateObj() => new(GetRandom.Value<CharacterData>());
        [TestMethod] public void FirstNameTest() => IsReadOnly(obj.Data.FirstName);
        [TestMethod] public void LastNameTest() => IsReadOnly(obj.Data.LastName);
        [TestMethod] public void OrganisationTest() => IsReadOnly(obj.Data.Organisation);
        [TestMethod] public void HogwartsHouseTest() => IsReadOnly(obj.Data.HogwartsHouse);
        [TestMethod] public void GenderTest() => IsReadOnly(obj.Data.Gender);
        [TestMethod] public void DoBTest() => IsReadOnly(obj.Data.DoB);
        [TestMethod] public void ToStringTest() {
            var expected = $"{obj.FirstName} {obj.LastName}, {obj.Organisation} ({obj.Gender.Description()}, {obj.DoB}, {obj.HogwartsHouse})";
            AreEqual(expected, obj.ToString());
        }
        [TestMethod] public void CharacterAddressesTest() => TestList<ICharacterAddressesRepo, CharacterAddress, CharacterAddressData>(
                d => d.CharacterID = obj.ID, d => new CharacterAddress(d), () => obj.CharacterAddresses);
        [TestMethod] public void AddressesTest() => IsInconclusive();

    }
}
