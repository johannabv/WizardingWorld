using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class CoreMaterialViewTests : SealedClassTests<CoreMaterialView, NamedView> {
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full info");
    }
}
