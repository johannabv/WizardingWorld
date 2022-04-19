using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class SpellTests : SealedClassTests<SpellData> {
        [TestMethod] public void SpellNameTest() => IsInconclusive();
        [TestMethod] public void DescriptionTest() => IsInconclusive();
        [TestMethod] public void TypeTest() => IsInconclusive();
        [TestMethod] public void ToStringTest() => IsInconclusive();
    }
}
