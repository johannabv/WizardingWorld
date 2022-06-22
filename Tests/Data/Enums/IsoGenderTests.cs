using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Enums;

namespace WizardingWorld.Tests.Data.Enums {
    [TestClass] public abstract class IsoGenderTests : TypeTests {
        [TestMethod] public void MaleTest() => DoTest(IsoGender.Male, 1, "Male");
        [TestMethod] public void FemaleTest() => DoTest(IsoGender.Female, 2, "Female");
        [TestMethod] public void NotKnownTest() => DoTest(IsoGender.NotKnown, 0, "Not known");
        [TestMethod] public void NotApplicableTest() => DoTest(IsoGender.NotApplicable, 9, "Not applicable");
        private static void DoTest(IsoGender isoGender, int value, string description) {
            AreEqual(value, (int)isoGender);
            AreEqual(description, isoGender.GetDescription());
        }
    }
}
