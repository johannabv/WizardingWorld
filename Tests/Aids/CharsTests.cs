﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;

namespace Tests.Aids {
    [TestClass] public class CharsTests : IsTypeTested {
        [TestMethod] public void IsNameCharTest() {
            Assert.IsTrue(Chars.IsNameChar('a'));
            Assert.IsTrue(Chars.IsNameChar('9'));
            Assert.IsTrue(Chars.IsNameChar('.'));
            Assert.IsTrue(Chars.IsNameChar('_'));
            Assert.IsFalse(Chars.IsNameChar(':'));
        }
    }
}
