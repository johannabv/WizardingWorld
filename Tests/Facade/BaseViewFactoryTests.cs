using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade {
    [TestClass] public class BaseViewFactoryTests : AbstractClassTests {
        private class TestClass : BaseViewFactory<CharacterView, Character, CharacterData> {
            protected override Character ToEntity(CharacterData d) => new(d);
        }
        protected override object createObj() => new TestClass();
    }
}
