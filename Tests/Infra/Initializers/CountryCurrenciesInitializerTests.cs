using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializer {
    [TestClass] public class CountryCurrenciesInitializerTests
        : SealedBaseTests<CountryCurrenciesInitializer, BaseInitializer<CountryCurrencyData>> {
        protected override CountryCurrenciesInitializer CreateObj() {
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            return new CountryCurrenciesInitializer(db);
        }
    }
}
