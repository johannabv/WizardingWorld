using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class CountryCurrencyDataTests : SealedClassTests<CountryCurrencyData, NamedData> {
        [TestMethod] public void CountryIDTest() => IsProperty<string>();
        [TestMethod] public void CurrencyIDTest() => IsProperty<string?>();
    }
}
