using Application.Parameters;
namespace Application.RepositoryInterfaces
{
    public interface IEntityRepository<EntityType, IdType> where EntityType : class
    {
        List<EntityType> GetAll<Q>(Q parameters) where Q : QueryParameters;
        Task<EntityType> GetById(IdType Id);
        Task<EntityType> Add(EntityType entity);
        Task<EntityType> Update(EntityType entity);
        Task Delete(IdType Id);
    }
}
