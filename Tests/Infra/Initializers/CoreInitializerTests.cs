using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializers {
    [TestClass] public class CoreInitializerTests
        : SealedBaseTests<CoresInitializer, BaseInitializer<CoreData>> {
        protected override CoresInitializer CreateObj() {
            var db = GetRepo.Instance<WizardingWorldDb>();
            return new CoresInitializer(db);
        }
    }
}
