using University.Core.DTOs;
using University.Core.Forms;
using University.Data.Entities;
using University.Data.Repositories;
using University.Core.Exceptions;
using University.Core.Validations;
using Microsoft.Extensions.Logging;

namespace University.Core.Services
{
    public class StudentService : IStudentService
    {
        public readonly IStudentRepository _studentRepository;
        public readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository studentRepository, ILogger<StudentService> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        public void Create(CreateStudentForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            var validation = FormValidator.Validate(form);

            if (!validation.IsValid)
                throw new BusinessException(validation.Errors);
 

            var student = new Student()
            {
                Name = form.Name,
                Email = form.Email
            };

            _studentRepository.Create(student);
            _studentRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student == null)
            {
                throw new NotFoundException("Student not found");
            }
            _studentRepository.Delete(student);
            _studentRepository.SaveChanges();
        }

        public List<StudentDTO> GetAll()
        {
            var allstudents = _studentRepository.GetAll();

            var dtos = allstudents.Select(student => new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            }).ToList();

            return dtos;
        }

        public StudentDTO GetById(int id)
        {
            _logger.LogInformation($"Somebody tried to call GetById {id}");
            var student = _studentRepository.GetById(id);

            if (student == null)
            {
                throw new NotFoundException("Student not found");
            }
            var dto = new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };

            return dto;
        }

        public void Update(int Id, UpdateStudentForm form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            var validation = FormValidator.Validate(form);
            if(!validation.IsValid)
                throw new BusinessException(validation.Errors);

            var student = _studentRepository.GetById(Id);

            if (student == null)
            {
                throw new NotFoundException("Student not found");
            }

            student.Name = form.Name;

            _studentRepository.Update(student);
            _studentRepository.SaveChanges();

        }
    }

    public interface IStudentService
    {
        StudentDTO GetById(int id);
        List<StudentDTO> GetAll();

        void Create(CreateStudentForm form);
        void Update(int Id, UpdateStudentForm form);
        void Delete(int id);

    }
}
