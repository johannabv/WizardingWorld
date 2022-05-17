using WizardingWorld.Aids;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Facade {
    public abstract class BaseViewFactory<TView, TEntity, TData>
    where TView : class, new()
    where TData : BaseData, new()
    where TEntity : BaseEntity<TData> {
        protected abstract TEntity ToEntity(TData d);
        protected virtual void Copying(object? from, object? to) => Copy.Properties(from, to);
        public virtual TEntity Create(TView? v) {
            var d = new TData();
            Copying(v, d);
            return ToEntity(d);
        }
        public virtual TView Create(TEntity? e) {
            var d = e?.Data;
            var v = new TView();
            Copying(d, v);
            return v;
        }
    }
}
