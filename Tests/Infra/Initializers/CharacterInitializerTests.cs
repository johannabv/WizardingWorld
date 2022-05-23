using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;

namespace WizardingWorld.Tests.Infra.Initializers {
    [TestClass] public class CharacterInitializerTests
        : SealedBaseTests<CharacterInitializer, BaseInitializer<CharacterData>> {
        protected override CharacterInitializer CreateObj() {
            WizardingWorldDb? db = GetRepo.Instance<WizardingWorldDb>();
            return new CharacterInitializer(db);
        }
    }
}
