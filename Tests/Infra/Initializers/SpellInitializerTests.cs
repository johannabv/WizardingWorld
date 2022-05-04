using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializers {
    [TestClass] public class SpellInitializerTests
        : SealedBaseTests<SpellInitializer, BaseInitializer<SpellData>> {
        protected override SpellInitializer CreateObj() {
            var db = GetRepo.Instance<WizardingWorldDb>();
            return new SpellInitializer(db);
        }
    }
}
