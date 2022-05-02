using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class WoodViewTests : SealedClassTests<WoodView, BaseView> {
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full info");
        [TestMethod] public void NameTest() => IsRequired<string?>("Name of wood");
        [TestMethod] public void TraitsTest() => IsDisplayNamed<string?>("Traits");
        [TestMethod] public void DescriptionTest() => IsRequired<string?>("Description");
    } 
}
