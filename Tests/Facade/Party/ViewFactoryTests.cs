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
        [TestMethod] public virtual void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            dynamic? v = GetRandom.Value<TView>();
            dynamic? o = obj.Create(v);
            ArePropertiesEqual(v, o.Data);
        }
        [TestMethod] public void CreateObjectTest() {
            dynamic? d = GetRandom.Value<TData>();
            dynamic? v = obj.Create(ToObject(d));
            ArePropertiesEqual(d, v);
        }
        protected abstract TObj ToObject(TData d);
    }
}
