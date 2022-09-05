using Application.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class IndustryRepository : IIndustryRepository
    {
        private readonly AppDbContext context;

        public IndustryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Task Add(Industry entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Industry> GetById(int Id , string[] expand)
        {
            IQueryable<Industry> industries = context.Industries;
            if (expand != null && expand.Length != 0)
            {
                industries = industries.Expand(expand);
            }
            var industry = await industries.FirstOrDefaultAsync(i => i.IndustryId == Id);
            if (industry != null)
                return industry;
            else
                throw new InvalidOperationException($"no existing industry with id = {Id}");
        }

        public Task Update(Industry entity)
        {
            throw new NotImplementedException();
        }
    }
}
