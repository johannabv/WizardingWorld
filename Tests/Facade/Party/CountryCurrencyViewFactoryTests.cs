using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class CountryCurrencyViewFactoryTests
        : ViewFactoryTests<CountryCurrencyViewFactory, CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
        protected override CountryCurrency ToObject(CountryCurrencyData d) => new(d);
    }
}
