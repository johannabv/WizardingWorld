using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;

namespace WizardingWorld.Infra.Initializers {
    public abstract class BaseInitializer<TData> where TData : BaseData{
        internal protected DbContext? Db;
        internal protected DbSet<TData>? Set;
        protected BaseInitializer(DbContext? context, DbSet<TData>? set) {
            Db = context;
            Set = set;
        }
        public void Init() {
            if (Set?.Any() ?? true) return;
            Set.AddRange(GetEntities);
            _ = (Db?.SaveChanges());
        }
        protected abstract IEnumerable<TData> GetEntities { get; }
        internal static bool IsCorrectIsoCode(string id) => !string.IsNullOrWhiteSpace(id) && char.IsLetter(id[0]);
    } 
}
