using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra {
    public abstract class FilteredRepo<TDomain, TData> : CrudRepo<TDomain, TData> 
        where TDomain : BaseEntity<TData>, new() where TData : BaseData, new() {
        protected FilteredRepo(DbContext? context, DbSet<TData>? set) : base(context, set) { }
        public string? CurrentFilter { get; set; }
        protected internal override IQueryable<TData> CreateSql() => AddFilter(base.CreateSql());
        internal virtual IQueryable<TData> AddFilter(IQueryable<TData> q) => q;
    }
}
