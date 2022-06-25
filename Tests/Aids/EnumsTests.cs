using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Enums;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class EnumsTests : TypeTests {
        [TestMethod] public void DescriptionTest()
             => AreEqual("Not applicable", IsoGender.NotApplicable.GetDescription());
        [TestMethod] public void ToStringTest()
              => AreEqual("NotApplicable", IsoGender.NotApplicable.ToString());
    }
}
