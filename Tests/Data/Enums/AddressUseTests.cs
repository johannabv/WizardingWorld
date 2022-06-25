using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Enums;

namespace WizardingWorld.Tests.Data.Enums {
    [TestClass] public abstract class AddressUseTests : TypeTests {
        [TestMethod] public void SchoolTest() => DoTest(AddressUse.School, 1, "School");
        [TestMethod] public void JobTest() => DoTest(AddressUse.Job, 2, "Job");
        [TestMethod] public void NotKnownTest() => DoTest(AddressUse.NotKnown, 0, "Not known");
        [TestMethod] public void HeadquartersTest() => DoTest(AddressUse.Headquarters, 3, "Headquarters");
        [TestMethod] public void HomeTest() => DoTest(AddressUse.Home, 4, "Home");
        [TestMethod] public void OtherTest() => DoTest(AddressUse.Other, 5, "Other");
        private static void DoTest(AddressUse addressUse, int value, string description) {
            AreEqual(value, (int)addressUse);
            AreEqual(description, addressUse.GetDescription());
        }
    }
}
