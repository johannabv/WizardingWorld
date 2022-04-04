using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra {
    public abstract class CrudRepo<TDomain, TData> : BaseRepo<TDomain, TData> 
        where TDomain : BaseEntity<TData>, new() where TData : BaseData, new() {
        protected CrudRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
        public override bool Add(TDomain obj) => AddAsync(obj).GetAwaiter().GetResult();
        public override bool Delete(string id) => DeleteAsync(id).GetAwaiter().GetResult();
        public override List<TDomain> Get() => GetAsync().GetAwaiter().GetResult();
        public override List<TDomain>? GetAll<TKey>(Func<TDomain, TKey>? orderBy = null) {
            var r = new List<TDomain>();
            if (set is null) return r;
            foreach(var d in set) r.Add(ToDomain(d));
            return (orderBy is null)? r : r.OrderBy(orderBy).ToList();  
        }
        public override TDomain Get(string id) => GetAsync(id).GetAwaiter().GetResult();
        public override bool Update(TDomain obj) => UpdateAsync(obj).GetAwaiter().GetResult();
        public override async Task<bool> AddAsync(TDomain obj) {
            var d = obj.Data;
            try {
                _ = (set is null) ? null : await set.AddAsync(d);
                _ = (db is null) ? 0 : await db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public override async Task<bool> DeleteAsync(string id) {
            try {
                var d = (set is null) ? null : await set.FindAsync(id);
                if (d == null) return false;
                _ = set?.Remove(d);
                _ = (db is null) ? 0 : await db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public override async Task<List<TDomain>> GetAsync() {
            try {
                var list = await CrudRepo<TDomain, TData>.RunSQL(CreateSQL());
                var items = new List<TDomain>();
                foreach (var d in list) items.Add(ToDomain(d));
                return items;
            }
            catch { return new List<TDomain>(); }
        }
        internal static async Task<List<TData>> RunSQL(IQueryable<TData> query) => await query.AsNoTracking().ToListAsync(); 
        internal protected virtual IQueryable<TData> CreateSQL() => from s in set select s; 
        public override async Task<TDomain> GetAsync(string id) {
            try {
                if (id == null) return new TDomain();
                var d = (set is null) ? null : await set.FirstOrDefaultAsync(m => m.ID == id);
                return d == null ? new TDomain() : ToDomain(d);
            }
            catch { return new TDomain(); }
        }
        public override async Task<bool> UpdateAsync(TDomain obj) {
            try {
                var d = obj.Data;
                if (db is not null) db.Attach(d).State = EntityState.Modified;
                _ = (db is null) ? 0 : await db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        protected abstract TDomain ToDomain(TData d);
    }
}
