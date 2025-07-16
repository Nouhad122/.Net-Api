using University.Data.Contexts;
using University.Data.Entities;

namespace University.Data.Repositories
{

    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext _context;
        public CourseRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public void Create(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Add(course);
        }

        public void Delete(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Remove(course);
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void Update(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            _context.Courses.Update(course);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }

    public interface ICourseRepository
    {
        Course GetById(int id);
        List<Course> GetAll();
        void Create(Course course);
        void Update(Course course);
        void Delete(Course course);
        void SaveChanges();
    }
}
