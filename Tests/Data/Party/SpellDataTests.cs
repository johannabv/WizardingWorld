using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class SpellDataTests : SealedClassTests<SpellData> {
        [TestMethod] public void SpellNameTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
        [TestMethod] public void TypeTest() => IsProperty<string?>();
    }
}
