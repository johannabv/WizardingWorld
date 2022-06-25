using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Tests.Domain.Party {
    [TestClass] public class WandTests : SealedClassTests<Wand, BaseEntity<WandData>> {
        protected override Wand CreateObj() => new(GetRandom.Value<WandData>());
        [TestMethod] public void CoreIdTest() => IsReadOnly(Obj.Data.CoreId);
        [TestMethod] public void WoodIdTest() => IsReadOnly(Obj.Data.WoodId);
        [TestMethod] public void InfoTest() => IsReadOnly(Obj.Data.Info);
        [TestMethod] public void WoodItemTest()
            => TestItem<IWoodsRepo, Wood, WoodData>(Obj.WoodId, d => new Wood(d), () => Obj.WoodItem);
        [TestMethod] public void CoreItemTest()
            => TestItem<ICoreMaterialsRepo, CoreMaterial, CoreMaterialData>(Obj.CoreId, d => new CoreMaterial(d), () => Obj.CoreItem);
        [TestMethod] public void WoodsTest() => TestList<IWoodsRepo, Wood, WoodData>(
                d => d.Name = Obj.WoodId, d => new Wood(d), () => Obj.Woods.Value); 
        [TestMethod] public void ToStringTest() {
            string expected = $"{Obj.Info},{Obj.CoreItem}, {Obj.WoodItem}";
            AreEqual(expected, Obj.ToString());
        }
    }
}
