using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Facade;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class SpellViewTests : SealedClassTests<SpellView, BaseView>{
        [TestMethod] public void IDTest() => IsProperty<string>();
        [TestMethod] public void SpellNameTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
        [TestMethod] public void TypeTest() => IsProperty<string?>();
    }
}
