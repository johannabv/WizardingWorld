using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>> {
        [TestInitialize] public void TestInitialize() {
            (GetRepo.Instance<ICountryCurrenciesRepo>() as CountryCurrenciesRepo)?.Clear();
        }
        [TestMethod] public void CountryCurrenciesTest() => TestList<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(
                d => d.CountryID = obj.ID, d => new CountryCurrency(d), () => obj.CountryCurrencies);
        [TestMethod] public void CurrenciesTest() => IsInconclusive();
    }
}
