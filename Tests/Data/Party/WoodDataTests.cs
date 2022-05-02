using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Data.Party {
    [TestClass] public class WoodDataTests : SealedClassTests<WoodData, BaseData> {
        [TestMethod] public void NameTest() => IsProperty<string?>();
        [TestMethod] public void TraitsTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
    }
}
