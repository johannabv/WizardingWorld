using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra {
    public abstract class PagedRepo<TDomain, TData> : OrderedRepo<TDomain, TData> 
        where TDomain : BaseEntity<TData>, new() where TData : BaseData, new() {
        protected PagedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
