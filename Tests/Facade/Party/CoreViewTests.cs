using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CoreViewTests : SealedClassTests<CoreView, NamedView> {
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full info");
    }
}
