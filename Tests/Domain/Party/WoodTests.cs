using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class WoodTests : SealedClassTests<Wood, BaseEntity<WoodData>> {
        protected override Wood CreateObj() => new(GetRandom.Value<WoodData>());
        [TestMethod] public void NameTest() => IsReadOnly(obj.Data.Name);
        [TestMethod] public void TraitsTest() => IsReadOnly(obj.Data.Traits);
        [TestMethod] public void DescriptionTest() => IsReadOnly(obj.Data.Description);
        [TestMethod] public void ToStringTest() {
            var expected = $"{obj.Name}: {obj.Traits}";
            AreEqual(expected, obj.ToString());
        }
    }
}
