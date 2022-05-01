using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;
using WizardingWorld.Tests.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class AddressViewFactoryTests
        : ViewFactoryTests<AddressViewFactory, AddressView, Address, AddressData> {
        protected override Address ToObject(AddressData d) => new(d);
    }
}
