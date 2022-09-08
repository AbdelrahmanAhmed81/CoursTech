using Application.Parameters;
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    public interface IIndustryRepository : IEntityRepository<Industry , int>
    {
        Task<List<Industry>> GetAll();

    }
}
