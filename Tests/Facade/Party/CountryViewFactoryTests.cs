using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class CountryViewFactoryTests
        : ViewFactoryTests<CountryViewFactory, CountryView, Country, CountryData> {
        protected override Country ToObject(CountryData d) => new(d);
    }
}
