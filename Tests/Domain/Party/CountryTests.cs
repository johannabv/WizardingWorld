using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>> {   
        [TestMethod] public void CountryCurrenciesTest() => TestList<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(
                d => d.CountryID = obj.ID, d => new CountryCurrency(d), () => obj.CountryCurrencies);
        [TestMethod] public void CurrenciesTest() => TestRelatedLists<ICurrenciesRepo, CountryCurrency, Currency, CurrencyData>
            (CountryCurrenciesTest, () => obj.CountryCurrencies, () => obj.Currencies,
                x => x.CurrencyID, d => new Currency(d), c => c?.Data, x => x?.Currency?.Data);
    }
}
