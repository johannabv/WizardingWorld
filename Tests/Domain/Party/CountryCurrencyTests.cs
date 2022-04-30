using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CountryCurrencyTests : SealedClassTests<CountryCurrency, NamedEntity<CountryCurrencyData>> {
        protected override CountryCurrency CreateObj() => new(GetRandom.Value<CountryCurrencyData>());
        [TestMethod] public void CurrencyIDTest() => IsReadOnly(obj.Data.CurrencyID);
        [TestMethod] public void CountryIDTest() => IsReadOnly(obj.Data.CountryID);
        [TestMethod] public void CountryTest()
            => TestItem<ICountriesRepo, Country, CountryData>(obj.CountryID, d => new Country(d), () => obj.Country);
        [TestMethod] public void CurrencyTest()
            => TestItem<ICurrenciesRepo, Currency, CurrencyData>(obj.CurrencyID, d => new Currency(d), () => obj.Currency);
    }
}
