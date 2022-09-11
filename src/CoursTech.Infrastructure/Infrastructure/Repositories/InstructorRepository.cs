using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext context;

        public InstructorRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Task Add(Instructor entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Instructor>> GetAll()
        {
            List<Instructor> result = await context.Instructors.AsNoTracking().ToListAsync();
            return result;
        }

        public Task<Instructor> GetById(string Id , string[] expand)
        {
            throw new NotImplementedException();
        }

        public Task Update(Instructor entity)
        {
            throw new NotImplementedException();
        }
    }
}
