using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class HouseDataTests : SealedClassTests<HouseData, BaseData> {
        [TestMethod] public void HouseNameTest() => IsProperty<string?>();
        [TestMethod] public void FounderNameTest() => IsProperty<string?>();
        [TestMethod] public void HeadOfHouseNameTest() => IsProperty<string?>();
        [TestMethod] public void ColorTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
    }
}
