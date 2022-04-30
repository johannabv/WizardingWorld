using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class CharsTests : TypeTests {
        private char letter;
        private char digit;

        [TestInitialize] public void Init() {
            letter = GetRandom.Char('a', 'z');
            digit = GetRandom.Char('0', '9');
        }
        [TestMethod] public void IsNameCharTest() {
            Assert.IsTrue(letter.IsNameChar());
            Assert.IsTrue(digit.IsNameChar());
            Assert.IsFalse('.'.IsNameChar());
            Assert.IsFalse('_'.IsNameChar());
            Assert.IsFalse(':'.IsNameChar());
            Assert.IsTrue('`'.IsNameChar());
        }
        [TestMethod] public void IsFullNameCharTest() {
            Assert.IsTrue(letter.IsFullNameChar());
            Assert.IsTrue(digit.IsFullNameChar());
            Assert.IsTrue('.'.IsFullNameChar());
            Assert.IsTrue('`'.IsFullNameChar());
            Assert.IsFalse('_'.IsFullNameChar());
            Assert.IsFalse(':'.IsFullNameChar());
        } 
    }
}
