using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursos.Interfaces;
using WebApiCursos.Model;

namespace WebApiCursos.Providers
{
    public class FakeCoursesProvider : ICoursesProvider
    {
        private readonly List<Course> repo = new List<Course>();
        public FakeCoursesProvider()
        {
            repo.Add(new Course()
            {
                Id = 1,
                Name = "Programación orientada a objetos",
                Author = "Jesús Enrique FLores",
                Description = "Iniciate en el mundo de la POO",
                Uri = "http://www.fake.com.mx"
            });
            repo.Add(new Course()
            {
                Id = 2,
                Name = "Principios de diseño de software",
                Author = "Jesús Enrique FLores",
                Description = "Iniciate el diseño de software, aprende sobre patrones de diseño y SOLID",
                Uri = "http://www.fake.com.mx"
            });
            repo.Add(new Course()
            {
                Id = 3,
                Name = "Diseño de software",
                Author = "Jesús Enrique FLores",
                Description = "Aprende sobre patrones arquitectonicos",
                Uri = "http://www.fake.com.mx"
            });
            repo.Add(new Course()
            {
                Id = 4,
                Name = "Desarrollo web",
                Author = "Jesús Enrique FLores",
                Description = "Aprende a crear aplicaciones web con Vuejs, html y css",
                Uri = "http://www.fake.com.mx"
            });

        }

        public Task<(bool isSuccess, int? Id)> AddAsync(Course course)
        {
            course.Id = repo.Max(c => c.Id) + 1;
            repo.Add(course);
            return Task.FromResult((true,(int?)course.Id));
        }

        public Task<ICollection<Course>> GetAllAsync()
        {
            return Task.FromResult((ICollection<Course>)repo.ToList());
        }

        public Task<Course> GetAsync(int id)
        {
            return Task.FromResult(repo.FirstOrDefault(c=>c.Id==id));
        }

        public Task<ICollection<Course>> SearchAsync(string search)
        {
            return Task.FromResult((ICollection<Course>) repo.Where(c=>c.Name.ToLowerInvariant().Contains(search.ToLowerInvariant())).ToList());
        }

        public Task<bool> UpdateAsync(Course course)
        {
            var courseToUpdate = repo.FirstOrDefault(c=>c.Id==course.Id);
            if (courseToUpdate != null)
            {
                courseToUpdate.Name = course.Name;
                courseToUpdate.Author = course.Author;
                courseToUpdate.Description = course.Description;
                courseToUpdate.Uri = course.Uri;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
