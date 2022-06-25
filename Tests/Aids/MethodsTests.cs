using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class MethodsTests : TypeTests {
        [TestMethod] public void HasAttributeTest() {
            MethodInfo? methodInfo = GetType().GetMethod(nameof(HasAttributeTest));
            IsTrue(methodInfo.HasAttribute<TestMethodAttribute>());
            IsFalse(methodInfo.HasAttribute<TestInitializeAttribute>());
        }
        [TestMethod] public void GetAttributeTest() {
            MethodInfo? methodInfo = GetType().GetMethod(nameof(GetAttributeTest));
            IsNotNull(Methods.GetAttribute<TestMethodAttribute>(methodInfo));
            IsNull(Methods.GetAttribute<TestInitializeAttribute>(methodInfo));
        }
    }
}
