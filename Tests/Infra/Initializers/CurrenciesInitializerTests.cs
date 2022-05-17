using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializer {
    [TestClass] public class CurrenciesInitializerTests
        : SealedBaseTests<CurrenciesInitializer, BaseInitializer<CurrencyData>> {
        protected override CurrenciesInitializer CreateObj() {
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            return new CurrenciesInitializer(db);
        }
    }
}
