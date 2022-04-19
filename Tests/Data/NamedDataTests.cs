using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data;

namespace WizardingWorld.Tests.Data {
    [TestClass] public class NamedDataTests : AbstractClassTests<NamedData, BaseData> {
        private class TestClass : NamedData { }
        protected override NamedData CreateObj() => new TestClass();
        [TestMethod] public void CodeTest() => IsProperty<string>();
        [TestMethod] public void NameTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
    }
}
