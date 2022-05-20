using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class StringsTests : TypeTests {
        private string? testStr;
        [TestInitialize] public void Init() => testStr = "a1b1c1.d1e1f1.g1h1i1";
        [TestMethod] public void RemoveTest() => AreEqual("abc.def.ghi", Strings.Remove(testStr, "1"));
        [TestMethod] public void IsTypeNameTest() {
            IsFalse(testStr.IsTypeName());
            string? s = testStr.Remove("1");
            IsFalse(s.IsTypeName());
            s = s.RemoveTail();
            IsFalse(s.IsTypeName());
            s = s.RemoveTail();
            IsTrue(s.IsTypeName());
        }
        [TestMethod] public void IsTypeFullNameTest() {
            IsTrue(Strings.IsTypeFullName(testStr));
            IsTrue(Strings.IsTypeFullName(Strings.Remove(testStr, "1")));
        }
        [TestMethod] public void RemoveTailTest() => AreEqual("a1b1c1.d1e1f1", Strings.RemoveTail(testStr));
        [TestMethod] public void RemoveHeadTest() => AreEqual("d1e1f1.g1h1i1", Strings.RemoveHead(testStr));
    }
}
