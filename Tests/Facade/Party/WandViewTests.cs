using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class WandViewTests : SealedClassTests<WandView, BaseView> {
        [TestMethod] public void CoreIDTest() => IsRequired<string?>("Core");
        [TestMethod] public void WoodIDTest() => IsRequired<string?>("Wood");
        [TestMethod] public void InfoTest() => IsDisplayNamed<string?>("Info");
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full Wand Info");
    } 
}
