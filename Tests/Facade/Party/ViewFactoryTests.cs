using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Aids;
using WizardingWorld.Data;
using WizardingWorld.Domain;
using WizardingWorld.Facade;

namespace WizardingWorld.Tests.Facade.Party {
    public abstract class ViewFactoryTests<TFactory, TView, TObj, TData>
        : SealedClassTests<TFactory, BaseViewFactory<TView, TObj, TData>>
        where TFactory : BaseViewFactory<TView, TObj, TData>, new()
        where TView : class, new()
        where TData : BaseData, new()
        where TObj : BaseEntity<TData> {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var v = GetRandom.Value<TView>();
            var o = obj.Create(v);
            ArePropertiesEqual(v, o.Data);
        }
        [TestMethod] public void CreateObjectTest() {
            var d = GetRandom.Value<TData>();
            var v = obj.Create(ToObject(d));
            ArePropertiesEqual(d, v);
        }
        protected abstract TObj ToObject(TData d);
    }
}
