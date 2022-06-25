using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class SpellTests : SealedClassTests<Spell, BaseEntity<SpellData>> {
        protected override Spell CreateObj() => new(GetRandom.Value<SpellData>());
        [TestMethod] public void SpellNameTest() => IsReadOnly(Obj.Data.SpellName);
        [TestMethod] public void DescriptionTest() => IsReadOnly(Obj.Data.Description);
        [TestMethod] public void TypeTest() => IsReadOnly(Obj.Data.Type);
        [TestMethod] public void ToStringTest() {
            string expected = $"{Obj.SpellName} ({Obj.Type}), {Obj.Description}";
            AreEqual(expected, Obj.ToString());
        }
    }
}
