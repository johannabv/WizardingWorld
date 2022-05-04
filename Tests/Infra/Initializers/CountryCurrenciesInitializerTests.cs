using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializers {
    [TestClass] public class CountryCurrenciesInitializerTests
        : SealedBaseTests<CountryCurrenciesInitializer, BaseInitializer<CountryCurrencyData>> {
        protected override CountryCurrenciesInitializer CreateObj() {
            var db = GetRepo.Instance<WizardingWorldDb>();
            return new CountryCurrenciesInitializer(db);
        }
    }
}
