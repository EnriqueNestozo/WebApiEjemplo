using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursos.Model;

namespace WebApiCursos.Interfaces
{
    public interface ICoursesProvider
    {
        Task<ICollection<Course>> GetAllAsync();
        Task<Course> GetAsync(int id);

        Task<ICollection<Course>> SearchAsync(string search);

        Task<bool> UpdateAsync(Course course);

        Task<(bool isSuccess, int? Id)> AddAsync(Course course);
    }
}
