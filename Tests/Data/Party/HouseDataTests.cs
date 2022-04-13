using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Enums;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class HouseDataTests : SealedClassTests<HouseData> {
        [TestMethod] public void HouseNameTest() => IsProperty<string?>();
        [TestMethod] public void FounderNameTest() => IsProperty<string?>();
        [TestMethod] public void HeadOfHouseNameTest() => IsProperty<string?>();
        [TestMethod] public void ColorTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
    }
}
