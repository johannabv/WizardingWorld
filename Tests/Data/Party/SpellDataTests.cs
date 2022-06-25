using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class SpellDataTests : SealedClassTests<SpellData, BaseData> {
        [TestMethod] public void SpellNameTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
        [TestMethod] public void TypeTest() => IsProperty<string?>();
    }
}
