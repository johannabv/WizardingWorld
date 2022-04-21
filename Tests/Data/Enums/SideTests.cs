using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Enums;

namespace WizardingWorld.Tests.Data.Enums {
    [TestClass] public class SideTests : TypeTests {
        [TestMethod] public void OoPTest() => DoTest(Side.OoP, 1, "Order of the Phoenix");
        [TestMethod] public void DeathEatersTest() => DoTest(Side.DeathEaters, 2, "Deatheaters");
        [TestMethod] public void NotKnownTest() => DoTest(Side.NotKnown, 0, "Not known");
        [TestMethod] public void DATest() => DoTest(Side.DA, 3, "Dumbledore's Army");
        private static void DoTest(Side side, int value, string description) {
            AreEqual(value, (int)side);
            AreEqual(description, side.Description());
        }
    }
}
