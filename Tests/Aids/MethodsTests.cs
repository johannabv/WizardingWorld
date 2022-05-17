using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class MethodsTests : TypeTests {
        [TestMethod] public void HasAttributeTest() {
            MethodInfo? m = GetType().GetMethod(nameof(HasAttributeTest));
            IsTrue(m.HasAttribute<TestMethodAttribute>());
            IsFalse(m.HasAttribute<TestInitializeAttribute>());
        }
        [TestMethod] public void GetAttributeTest() {
            MethodInfo? m = GetType().GetMethod(nameof(GetAttributeTest));
            IsNotNull(Methods.GetAttribute<TestMethodAttribute>(m));
            IsNull(Methods.GetAttribute<TestInitializeAttribute>(m));
        }
    }
}
