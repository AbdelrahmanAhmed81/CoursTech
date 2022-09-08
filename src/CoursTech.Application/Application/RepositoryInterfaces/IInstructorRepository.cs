using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface IInstructorRepository:IEntityRepository<Instructor,string>
    {
        Task<List<Instructor>> GetAll();
    }
}
