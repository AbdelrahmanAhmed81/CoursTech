using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModels
{
    public class CoursesDataModel
    {
        public List<Course> Courses { get; set; }
        public int CoursesCount { get; set; }
    }
}
