using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class SpellTests : SealedClassTests<Spell, BaseEntity<SpellData>> {
        protected override Spell CreateObj() => new(GetRandom.Value<SpellData>());
        [TestMethod] public void SpellNameTest() => IsReadOnly(obj.Data.SpellName);
        [TestMethod] public void DescriptionTest() => IsReadOnly(obj.Data.Description);
        [TestMethod] public void TypeTest() => IsReadOnly(obj.Data.Type);
        [TestMethod] public void ToStringTest() {
            string expected = $"{obj.SpellName} ({obj.Type}), {obj.Description}";
            AreEqual(expected, obj.ToString());
        }
    }
}
