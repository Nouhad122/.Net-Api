using University.Data.Contexts;
using University.Data.Entities;

namespace University.Data.Repositories
{

    public class StudentRepository : IStudentRepository
{
    private readonly UniversityDbContext _context;
    public StudentRepository(UniversityDbContext context)
    {
        _context = context;
    }

    public void Create(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        student.CreatedTime = DateTime.Now;
        _context.Students.Add(student);
    }

    public void Delete(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        _context.Students.Remove(student);
    }

    public List<Student> GetAll()
    {
        return _context.Students.ToList();
    }

    public Student GetById(int id)
    {
        return _context.Students.Find(id);
    }

    public void Update(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        student.LastUpdatedTime = DateTime.Now;
        _context.Students.Update(student);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    }

public interface IStudentRepository
{
    Student GetById(int id);
    List<Student> GetAll();
    void Create(Student student);
    void Update(Student student);
    void Delete(Student student);
    void SaveChanges();
}
}
