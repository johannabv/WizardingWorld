using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Data;

namespace WizardingWorld.Tests.Data {
    [TestClass] public class BaseDataTests : AbstractClassTests<BaseData, object> {
        private class TestClass : BaseData { }
        protected override BaseData CreateObj() => new TestClass();
        [TestMethod] public void IDTest() => IsProperty<string>();
        [TestMethod] public void NewIdTest() {
            IsNotNull(BaseData.NewId);
            AreNotEqual(BaseData.NewId,BaseData.NewId);
            PropertyInfo? pi = typeof(BaseData).GetProperty(nameof(BaseData.NewId));
            IsFalse(pi?.CanWrite);
        }
    }
}
