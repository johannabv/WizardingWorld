using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CountryCurrencyTests : SealedClassTests<CountryCurrencyData> {
        [TestMethod] public void CurrencyIDTest() => IsInconclusive();
        [TestMethod] public void CountryIDTest() => IsInconclusive();
        [TestMethod] public void CountryTest() => IsInconclusive();
        [TestMethod] public void CurrencyTest() => IsInconclusive();
    }
}
