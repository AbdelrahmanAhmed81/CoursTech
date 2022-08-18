namespace Application.RepositoryInterfaces
{
    public interface IEntityRepository<T> where T : class
    {
        List<T> GetAll();
        Task<T> GetById(object Id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(object Id);
    }
}
