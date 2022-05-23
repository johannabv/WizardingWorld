using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class CurrencyViewFactoryTests
        : ViewFactoryTests<CurrencyViewFactory, CurrencyView, Currency, CurrencyData> {
        protected override Currency ToObject(CurrencyData d) => new(d);
    }
}
