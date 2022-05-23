using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class HouseViewFactoryTests
        : ViewFactoryTests<HouseViewFactory, HouseView, House, HouseData> {
        protected override House ToObject(HouseData d) => new(d);
    }
}
