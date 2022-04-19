using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class HouseTests : SealedClassTests<HouseData> {
        [TestMethod] public void HouseNameTest() => IsInconclusive();
        [TestMethod] public void FounderNameTest() => IsInconclusive();
        [TestMethod] public void HeadOfHouseNameTest() => IsInconclusive();
        [TestMethod] public void ColorTest() => IsInconclusive();
        [TestMethod] public void DescriptionTest() => IsInconclusive();
        [TestMethod] public void ToStringTest() => IsInconclusive();
        [TestMethod] public void CharactersTest() => IsInconclusive();
    }
}
