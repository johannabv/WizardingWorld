using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class AddressTests : SealedClassTests<Address, BaseEntity<AddressData>> {
        [TestInitialize] public void TestInitialize() => ((CountriesRepo)GetRepo.Instance<ICountriesRepo>())?.Clear();
        protected override Address CreateObj() => new (GetRandom.Value<AddressData>());
        [TestMethod] public void StreetTest() => IsReadOnly(obj.Data.Street);
        [TestMethod] public void CityTest() => IsReadOnly(obj.Data.City);
        [TestMethod] public void RegionTest() => IsReadOnly(obj.Data.Region);
        [TestMethod] public void ZipCodeTest() => IsReadOnly(obj.Data.ZipCode);
        [TestMethod] public void DescriptionTest() => IsReadOnly(obj.Data.Description);
        [TestMethod] public void CountryIDTest() => IsReadOnly(obj.Data.CountryID);
        [TestMethod] public void ToStringTest() => IsInconclusive();
        [TestMethod] public void CharactersTest() => IsInconclusive();
        [TestMethod] public void CharacterAddressesTest() => IsInconclusive();
        [TestMethod] public void CountryTest() 
            => testItem<ICountriesRepo, Country, CountryData>(obj.CountryID, d => new Country(d), () => obj.Country);
        
    }
}
