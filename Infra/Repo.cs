using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra {
    public abstract class Repo<TDomain, TData> : PagedRepo<TDomain, TData> where TDomain : BaseEntity<TData>, new() where TData : BaseData, new() {
        protected Repo(DbContext? c, DbSet<TData>? s) : base(c,s) { }
    }
}
