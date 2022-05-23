using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializers {
    [TestClass] public class CoreMaterialsInitializerTests
        : SealedBaseTests<CoreMaterialsInitializer, BaseInitializer<CoreMaterialData>> {
        protected override CoreMaterialsInitializer CreateObj() {
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            return new CoreMaterialsInitializer(db);
        }
    }
}
