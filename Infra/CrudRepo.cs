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
        public override List<TDomain> GetAll(Func<TDomain, dynamic>? orderBy = null) {
            var r = new List<TDomain>();
            if (Set is null) return r;
            foreach (var d in Set) r.Add(ToDomain(d));
            return (orderBy is null) ? r : r.OrderBy(orderBy).ToList();
        }
        public override TDomain Get(string id) => GetAsync(id).GetAwaiter().GetResult();
        public override bool Update(TDomain obj) => UpdateAsync(obj).GetAwaiter().GetResult();
        public override async Task<bool> AddAsync(TDomain obj) {
            var d = obj.Data;
            try {
                _ = (Set is null) ? null : await Set.AddAsync(d);
                _ = (Db is null) ? 0 : await Db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public override async Task<bool> DeleteAsync(string id) {
            try {
                var d = (Set is null) ? null : await Set.FindAsync(id);
                if (d == null) return false;
                _ = Set?.Remove(d);
                _ = (Db is null) ? 0 : await Db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public override async Task<List<TDomain>> GetAsync() {
            try {
                var query = CreateSQL();
                var list = await CrudRepo<TDomain, TData>.RunSQL(query);
                var items = new List<TDomain>();
                foreach (var d in list) items.Add(ToDomain(d));
                return items;
            }
            catch { return new List<TDomain>(); }
        }
        internal static async Task<List<TData>> RunSQL(IQueryable<TData> query) => await query.AsNoTracking().ToListAsync();
        internal protected virtual IQueryable<TData> CreateSQL() => from s in Set select s;
        public override async Task<TDomain> GetAsync(string id) {
            try {
                if (id == null) return new TDomain();
                var d = (Set is null) ? null : await Set.FirstOrDefaultAsync(x => x.ID == id);
                return d == null ? new TDomain() : ToDomain(d);
            }
            catch { return new TDomain(); }
        }
        public override async Task<bool> UpdateAsync(TDomain obj) {
            try {
                if(Db == null) return false;
                Db.ChangeTracker.Clear();
                var d = obj.Data;
                Db.Attach(d).State = EntityState.Modified;
                _ = await Db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        protected internal abstract TDomain ToDomain(TData d);
    }
}

