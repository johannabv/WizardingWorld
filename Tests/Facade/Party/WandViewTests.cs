using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class WandViewTests : SealedClassTests<WandView, BaseView> {
        [TestMethod] public void CoreTest() => IsRequired<string?>("Core");
        [TestMethod] public void WoodTest() => IsRequired<string?>("Wood");
        [TestMethod] public void CoreInfoTest() => IsDisplayNamed<string?>("Info about core");
        [TestMethod] public void WoodInfoTest() => IsDisplayNamed<string?>("Info about wood");
        [TestMethod] public void InfoTest() => IsDisplayNamed<string?>("Info");
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full Wand Info");
    } 
}
