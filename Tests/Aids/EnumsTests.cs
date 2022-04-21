using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Enums;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public class EnumsTests : TypeTests {
        [TestMethod] public void DescriptionTest()
             => AreEqual("Not applicable", IsoGender.NotApplicable.Description());
        [TestMethod] public void ToStringTest()
              => AreEqual("NotApplicable", IsoGender.NotApplicable.ToString());
    }
}
