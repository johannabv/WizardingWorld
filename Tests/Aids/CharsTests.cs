using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;

namespace Tests.Aids {
    [TestClass] public class CharsTests : IsTypeTested {
        [TestMethod] public void IsNameCharTest() {
            Assert.IsTrue(Chars.IsNameChar('a'));
            Assert.IsTrue(Chars.IsNameChar('9'));
            Assert.IsFalse(Chars.IsNameChar('.'));
            Assert.IsFalse(Chars.IsNameChar('_'));
            Assert.IsFalse(Chars.IsNameChar(':'));
        }
        [TestMethod] public void IsFullInfoCharTest() {
            Assert.IsTrue(Chars.IsFullInfoChar('a'));
            Assert.IsTrue(Chars.IsFullInfoChar('9'));
            Assert.IsTrue(Chars.IsFullInfoChar('.'));
            Assert.IsFalse(Chars.IsFullInfoChar('_'));
            Assert.IsFalse(Chars.IsFullInfoChar(':'));
        }
    }
}
