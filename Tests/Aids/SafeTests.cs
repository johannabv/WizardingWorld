using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests;
using WizardingWorld.Aids;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public class SafeTests : TypeTests {
        private int expected;
        private int def;
        [TestInitialize] public void Init() {
            expected = GetRandom.Int32();
            def = GetRandom.Int32();
        }
        [TestMethod] public void RunFuncTest() {
            var actual = Safe.Run(() => expected, def);
            AreEqual(expected, actual);
        }
        [TestMethod] public void RunFuncExceptionTest() {
            var actual = Safe.Run(() => throw new Exception(), def);
            AreEqual(def, actual);
        }
        [TestMethod] public void RunActionTest() => Safe.Run(() => throw new Exception());
        [TestMethod] public void RunTest() { }
    }
}
