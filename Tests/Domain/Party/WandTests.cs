using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class WandTests : SealedClassTests<Wand, BaseEntity<WandData>> {
        protected override Wand CreateObj() => new(GetRandom.Value<WandData>());
        [TestMethod] public void CoreIDTest() => IsReadOnly(obj.Data.CoreID);
        [TestMethod] public void WoodIDTest() => IsReadOnly(obj.Data.WoodID);
        [TestMethod] public void InfoTest() => IsReadOnly(obj.Data.Info);
        [TestMethod] public void WoodItemTest()
            => TestItem<IWoodsRepo, Wood, WoodData>(obj.WoodID, d => new Wood(d), () => obj.WoodItem);
        [TestMethod] public void CoreItemTest()
            => TestItem<ICoresRepo, Core, CoreData>(obj.CoreID, d => new Core(d), () => obj.CoreItem);
        [TestMethod] public void WoodsTest() => TestList<IWoodsRepo, Wood, WoodData>(
                d => d.Name = obj.WoodID, d => new Wood(d), () => obj.Woods); 
        [TestMethod] public void ToStringTest() {
            var expected = $"{obj.Info},{obj.CoreItem}, {obj.WoodItem}";
            AreEqual(expected, obj.ToString());
        }
    }
}
