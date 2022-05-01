using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;
using WizardingWorld.Tests.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CountryViewFactoryTests
        : ViewFactoryTests<CountryViewFactory, CountryView, Country, CountryData> {
        protected override Country ToObject(CountryData d) => new(d);
    }
}
