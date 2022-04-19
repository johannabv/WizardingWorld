using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CurrencyTests : SealedClassTests<Currency, NamedEntity<CurrencyData>> {
        [TestMethod] public void CountryCurrenciesTest() => IsInconclusive();
        [TestMethod] public void CountriesTest() => IsInconclusive();
    }
}
