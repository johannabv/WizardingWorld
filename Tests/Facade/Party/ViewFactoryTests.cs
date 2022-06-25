using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            dynamic? view = GetRandom.Value<TView>();
            dynamic? obj = Obj.Create(view);
            ArePropertiesEqual(view, obj.Data);
        }
        [TestMethod] public void CreateObjectTest() {
            dynamic? data = GetRandom.Value<TData>();
            dynamic? view = Obj.Create(ToObject(data));
            ArePropertiesEqual(data, view);
        }
        protected abstract TObj ToObject(TData d);
    }
}
