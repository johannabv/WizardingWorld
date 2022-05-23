using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Facade;

namespace WizardingWorld.Tests.Facade {
    [TestClass] public class BaseViewTests : AbstractClassTests<BaseView, object> {
        private class TestClass : BaseView { }
        protected override BaseView CreateObj() => new TestClass();
        [TestMethod] public void IDTest() => IsProperty<string>();
        [TestMethod] public void TokenTest() => IsProperty<byte[]>();
    }
}
