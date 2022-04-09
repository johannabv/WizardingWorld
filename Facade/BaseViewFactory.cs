﻿using System.Reflection;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Facade {
    public abstract class BaseViewFactory<TView, TEntity, TData>
    where TView : class, new()
    where TData : BaseData, new()
    where TEntity : BaseEntity<TData> {
        protected abstract TEntity ToEntity(TData d);
        protected virtual void Copy(object? from, object? to) {
            var tFrom = from?.GetType();
            var tTo = to?.GetType();
            foreach (var piFrom in tFrom?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
                var v = piFrom.GetValue(from, null);
                var piTo = tTo?.GetProperty(piFrom.Name);
                piTo?.SetValue(to, v, null);
            }
        }
        public virtual TEntity Create(TView? v) {
            var d = new TData();
            Copy(v, d);
            return ToEntity(d);
        }
        public virtual TView Create(TEntity? e) {
            var d = e?.Data;
            var v = new TView();
            Copy(d, v);
            return v;
        }
    }
}
