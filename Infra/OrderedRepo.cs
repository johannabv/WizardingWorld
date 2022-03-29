using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra {
    public abstract class OrderedRepo<TDomain, TData> : FilteredRepo<TDomain, TData>
        where TDomain : BaseEntity<TData>, new() where TData : BaseData, new() {
        protected OrderedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
