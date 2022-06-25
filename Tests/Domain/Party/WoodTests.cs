using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class WoodTests : SealedClassTests<Wood, BaseEntity<WoodData>> {
        protected override Wood CreateObj() => new(GetRandom.Value<WoodData>());
        [TestMethod] public void NameTest() => IsReadOnly(Obj.Data.Name);
        [TestMethod] public void TraitsTest() => IsReadOnly(Obj.Data.Traits);
        [TestMethod] public void DescriptionTest() => IsReadOnly(Obj.Data.Description);
        [TestMethod] public void ToStringTest() {
            string expected = $"{Obj.Name}: {Obj.Traits}";
            AreEqual(expected, Obj.ToString());
        }
    }
}
