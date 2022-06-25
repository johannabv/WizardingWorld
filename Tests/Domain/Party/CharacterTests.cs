using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CharacterTests : SealedClassTests<Character, BaseEntity<CharacterData>> {
        protected override Character CreateObj() => new(GetRandom.Value<CharacterData>());
        [TestMethod] public void FirstNameTest() => IsReadOnly(Obj.Data.FirstName);
        [TestMethod] public void LastNameTest() => IsReadOnly(Obj.Data.LastName);
        [TestMethod] public void OrganizationTest() => IsReadOnly(Obj.Data.Organization);
        [TestMethod] public void HogwartsHouseTest() => IsReadOnly(Obj.Data.HogwartsHouse);
        [TestMethod] public void GenderTest() => IsReadOnly(Obj.Data.Gender);
        [TestMethod] public void DoBTest() => IsReadOnly(Obj.Data.DoB);
        [TestMethod] public void ToStringTest() {
            string expected = $"{Obj.FirstName} {Obj.LastName}, {Obj.Organization} ({Obj.Gender.GetDescription()}, {Obj.DoB}, {Obj.HogwartsHouse})";
            AreEqual(expected, Obj.ToString());
        }
        [TestMethod] public void CharacterAddressesTest() => TestList<ICharacterAddressesRepo, CharacterAddress, CharacterAddressData>(
                d => d.CharacterId = Obj.Id, d => new CharacterAddress(d), () => Obj.CharacterAddresses.Value);
        [TestMethod] public void AddressesTest() => TestRelatedLists<IAddressRepo, CharacterAddress, Address, AddressData>
            (CharacterAddressesTest, () => Obj.CharacterAddresses.Value, () => Obj.Addresses.Value,
                x => x.AddressId, d => new Address(d), c => c?.Data, x => x?.Address?.Data);

    }
}
