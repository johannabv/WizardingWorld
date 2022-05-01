using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CurrencyTests : SealedClassTests<Currency, NamedEntity<CurrencyData>> {
        [TestMethod] public void CountryCurrenciesTest() => TestList<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(
                d => d.CurrencyID = obj.ID, d => new CountryCurrency(d), () => obj.CountryCurrencies);
        [TestMethod] public void CountriesTest() => TestRelatedLists<ICountriesRepo, CountryCurrency, Country, CountryData>
            (CountryCurrenciesTest, () => obj.CountryCurrencies, () => obj.Countries,
                x => x.CountryID, d => new Country(d), c => c?.Data, x => x?.Country?.Data);
    }
}
