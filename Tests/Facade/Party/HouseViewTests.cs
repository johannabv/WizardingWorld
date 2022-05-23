using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class HouseViewTests : SealedClassTests<HouseView, BaseView> {
        [TestMethod] public void HouseNameTest() => IsRequired<string?>("House name");
        [TestMethod] public void FounderNameTest() => IsDisplayNamed<string?>("Founder name");
        [TestMethod] public void HeadOfHouseNameTest() => IsDisplayNamed<string?>("Head of House name");
        [TestMethod] public void ColorTest() => IsRequired<string?>("Color");
        [TestMethod] public void DescriptionTest() => IsDisplayNamed<string?>("Description");
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full info");
    }
}
