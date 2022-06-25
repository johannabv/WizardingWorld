using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public class CopyTests : TypeTests{
        [TestMethod] public void PropertiesTest() {
            CoreMaterialData? initA = new CoreMaterialData() { 
                Name = GetRandom.String(),
                Description = GetRandom.String(),
                Code = GetRandom.String()
            };
            CoreMaterialData? initB = new CoreMaterialData();
            Copy.Properties(initA, initB);
            AreEqual(initA.Name, initB.Name);
            AreEqual(initA.Description, initB.Description);
            AreEqual(initA.Code, initB.Code);
        }
    }
}
