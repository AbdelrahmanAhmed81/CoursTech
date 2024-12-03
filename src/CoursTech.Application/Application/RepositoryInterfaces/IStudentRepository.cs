using Application.DataModels;
using Domain.Entities;

namespace Application.RepositoryInterfaces
{
    internal interface IStudentRepository:IEntityRepository<Student,string>
    {
        Task Add(StudentDataModel entity);
    }
}
