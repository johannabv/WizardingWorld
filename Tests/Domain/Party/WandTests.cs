using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass]
    public class WandTests : SealedClassTests<Wand, BaseEntity<WandData>> {
        protected override Wand CreateObj() => new(GetRandom.Value<WandData>());
        [TestMethod] public void CoreTest() => IsReadOnly(obj.Data.Core);
        [TestMethod] public void CoreInfoTest() => IsReadOnly(obj.Data.CoreInfo);
        [TestMethod] public void WoodTest() => IsReadOnly(obj.Data.Wood);
        [TestMethod] public void WoodInfoTest() => IsReadOnly(obj.Data.WoodInfo);
        [TestMethod] public void InfoTest() => IsReadOnly(obj.Data.Info);
        [TestMethod] public void ToStringTest() {
            var expected = $"{obj.Info},{obj.Core}, {obj.Wood}";
            AreEqual(expected, obj.ToString());
        }
    }
}
