using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class CountryCurrencyViewTests : SealedClassTests<CountryCurrencyView, NamedView> {
        [TestMethod] public void CountryIDTest() => IsRequired<string>("Country");
        [TestMethod] public void CurrencyIDTest() => IsRequired<string>("Currency");
        [TestMethod] public void NameTest() => IsRequired<string?>("Currency native name");
        [TestMethod] public void CodeTest() => IsRequired<string?>("Currency native name");
    }
}
