using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Facade;

namespace WizardingWorld.Tests.Facade {
    [TestClass] public class NamedViewTests : AbstractClassTests<NamedView, BaseView> {
        private class TestClass : NamedView { }
        protected override NamedView CreateObj() => new TestClass();
        [TestMethod] public void CodeTest() => IsDisplayNamed<string>("Code");
        [TestMethod] public void NameTest() => IsRequired<string>("Name");
        [TestMethod] public void DescriptionTest() => IsRequired<string>("GetDescription");
    }
}
