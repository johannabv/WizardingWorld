﻿namespace WizardingWorld.Domain {
    public interface IRepo<T> : IPagedRepo<T> where T : BaseEntity { }
    public interface IPagedRepo<T> : IOrderedRepo<T> where T : BaseEntity {
        public int PageIndex { get; set; }
        public int TotalPages { get;}
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }
        public int PageSize { get; set; } 
    }
    public interface IOrderedRepo<T> : IFilteredRepo<T> where T : BaseEntity { 
        public string? CurrentSort { get; set; }
        public string SortOrder(string propertyName);
    }
    public interface IFilteredRepo<T> : ICrudRepo<T> where T : BaseEntity { 
        public string? CurrentFilter { get; set; }
    }
    public interface ICrudRepo<T> : IBaseRepo<T> where T : BaseEntity { }
    public interface IBaseRepo<T> where T : BaseEntity {
        bool Add(T obj);
        List<T> Get();
        List<T> GetAll<TKey>(Func<T, TKey>? orderBy = null);
        T Get(string id);
        bool Delete(string id);
        bool Update(T obj); 
        Task<bool> AddAsync(T obj);
        Task<List<T>> GetAsync();
        Task<T> GetAsync(string id);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(string id);
    }
}
