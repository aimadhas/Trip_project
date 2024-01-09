namespace Trip_project.Interfaces
{
    public interface IGenericInterface<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(Guid id);
        public Task<T> CreatEntity(T entity);
        public Task<T> UpdateEntity(Guid id ,T entity);
        public Task<T> DeleteEntity(Guid id);

    }
}
