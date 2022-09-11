using Application.Parameters;
namespace Application.RepositoryInterfaces
{
    public interface IEntityRepository<EntityType, IdType> where EntityType : class
    {
        Task<EntityType> GetById(IdType Id,string[] expand);
        Task Update(EntityType entity);
        Task Delete(IdType Id);
    }
}
