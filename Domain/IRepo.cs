namespace WizardingWorld.Domain {
    public interface IRepo<T> : IBaseRepo<T> where T : BaseEntity { } 
    public interface IBaseRepo<T> where T : BaseEntity {
        bool Add(T obj);
        List<T> Get();
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
