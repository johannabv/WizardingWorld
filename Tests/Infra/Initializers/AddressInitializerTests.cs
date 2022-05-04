using Microsoft.VisualStudio.TestTools.UnitTesting; 
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializers {
    [TestClass] public class AddressInitializerTests
        : SealedBaseTests<AddressInitializer, BaseInitializer<AddressData>> {
        protected override AddressInitializer CreateObj() {
            var db = GetRepo.Instance<WizardingWorldDb>();
            return new AddressInitializer(db);
        }
    }
}
