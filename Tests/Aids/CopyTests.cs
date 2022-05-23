using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public class CopyTests : TypeTests{
        [TestMethod] public void PropertiesTest() {
            var initA = new CoreMaterialData() { 
                Name=GetRandom.String(),
                Description = GetRandom.String(),
                Code = GetRandom.String()
            };
            var initB = new CoreMaterialData();
            Copy.Properties(initA, initB);
            AreEqual(initA.Name, initB.Name);
            AreEqual(initA.Description, initB.Description);
            AreEqual(initA.Code, initB.Code);
        }
    }
}
