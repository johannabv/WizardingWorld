using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class AddressViewFactoryTests
        : ViewFactoryTests<AddressViewFactory, AddressView, Address, AddressData> {
        protected override Address ToObject(AddressData d) => new(d);
        [TestMethod] public override void CreateTest() { }
    }
}
