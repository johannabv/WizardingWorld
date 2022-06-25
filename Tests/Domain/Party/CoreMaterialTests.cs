using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class CoreMaterialTests : SealedClassTests<CoreMaterial, NamedEntity<CoreMaterialData>> {
        protected override CoreMaterial CreateObj() => new(GetRandom.Value<CoreMaterialData>());
        [TestMethod] public void ToStringTest() {
            string expected = $"{Obj.Name}: {Obj.Description}";
            AreEqual(expected, Obj.ToString());
        }
    }
}
