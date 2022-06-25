using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class AddressTests : SealedClassTests<Address, BaseEntity<AddressData>> {
        protected override Address CreateObj() => new (GetRandom.Value<AddressData>());
        [TestMethod] public void StreetTest() => IsReadOnly(Obj.Data.Street);
        [TestMethod] public void CityTest() => IsReadOnly(Obj.Data.City);
        [TestMethod] public void RegionTest() => IsReadOnly(Obj.Data.Region);
        [TestMethod] public void ZipCodeTest() => IsReadOnly(Obj.Data.ZipCode);
        [TestMethod] public void DescriptionTest() => IsReadOnly(Obj.Data.Description);
        [TestMethod] public void CountryIdTest() => IsReadOnly(Obj.Data.CountryId);
        [TestMethod] public void ToStringTest() {
            string expected = $"{Obj.Street}, {Obj.City}, {Obj.Country?.Name} ({Obj.Description})";
            AreEqual(expected, Obj.ToString());
        }
        [TestMethod] public void CharactersTest() 
            => TestRelatedLists<ICharactersRepo, CharacterAddress, Character, CharacterData>
            (CharacterAddressesTest, () => Obj.CharacterAddresses.Value, () => Obj.Characters.Value, 
                x => x.CharacterId, d => new Character(d), c => c?.Data, x => x?.Character?.Data);
        [TestMethod] public void CharacterAddressesTest() 
            => TestList<ICharacterAddressesRepo, CharacterAddress, CharacterAddressData>(
                d => d.AddressId = Obj.Id, d => new CharacterAddress(d), () => Obj.CharacterAddresses.Value);
        [TestMethod] public void CountryTest() 
            => TestItem<ICountriesRepo, Country, CountryData>(Obj.CountryId, d => new Country(d), () => Obj.Country);
        
    }
}
