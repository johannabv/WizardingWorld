using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class HouseViewTests : SealedClassTests<HouseView, BaseView> {
        [TestMethod] public void HouseNameTest() => IsRequired<string?>("House name");
        [TestMethod] public void FounderNameTest() => IsDisplayNamed<string?>("Founder name");
        [TestMethod] public void HeadOfHouseNameTest() => IsDisplayNamed<string?>("Head of House name");
        [TestMethod] public void ColorTest() => IsRequired<string?>("Color");
        [TestMethod] public void DescriptionTest() => IsDisplayNamed<string?>("GetDescription");
        [TestMethod] public void FullNameTest() => IsDisplayNamed<string?>("Full info");
    }
    [TestClass] public class HouseViewFactoryTests
        : ViewFactoryTests<HouseViewFactory, HouseView, House, HouseData> {
        protected override House ToObject(HouseData d) => new(d);
    }
}
