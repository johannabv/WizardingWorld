﻿using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra {
    public abstract class BaseRepo<TDomain, TData> : IBaseRepo<TDomain>
        where TDomain : BaseEntity<TData>, new() where TData : BaseData, new() {
        protected internal readonly DbContext? db;
        protected internal readonly DbSet<TData>? set;
        protected BaseRepo(DbContext? c, DbSet<TData>? s) {
            db = c;
            set = s;
        }
        internal void Clear() {
            set?.RemoveRange(set);
            db?.SaveChanges();
        }
        public abstract bool Add(TDomain obj);
        public abstract Task<bool> AddAsync(TDomain obj);
        public abstract bool Delete(string id);
        public abstract Task<bool> DeleteAsync(string id);
        public abstract List<TDomain> Get();
        public abstract List<TDomain> GetAll(Func<TDomain, dynamic>? orderBy = null);
        public abstract TDomain Get(string id);
        public abstract Task<List<TDomain>> GetAsync();
        public abstract Task<TDomain> GetAsync(string id);
        public abstract bool Update(TDomain obj);
        public abstract Task<bool> UpdateAsync(TDomain obj);
    }
}
