using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class MethodsTests : TypeTests {
        [TestMethod] public void HasAttributeTest() {
            var m = GetType().GetMethod(nameof(HasAttributeTest));
            IsTrue(m.HasAttribute<TestMethodAttribute>());
            IsFalse(m.HasAttribute<TestInitializeAttribute>());
        }
    }
}
