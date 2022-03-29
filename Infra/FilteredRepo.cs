using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra {
    public abstract class FilteredRepo<TDomain, TData> : CrudRepo<TDomain, TData> 
        where TDomain : BaseEntity<TData>, new() where TData : BaseData, new() {
        protected FilteredRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
