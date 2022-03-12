using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class SpellViewTests : SealedClassTests<SpellView>{
        [TestMethod] public void IDTest() => isProperty<string?>();
        [TestMethod] public void SpellNameTest() => isProperty<string?>();
        [TestMethod] public void DescriptionTest() => isProperty<string?>();
        [TestMethod] public void TypeTest() => isProperty<string?>();
    }
}
