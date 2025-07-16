using University.Core.DTOs;
using University.Core.Forms;
using University.Data.Entities;
using University.Data.Repositories;
using University.Core.Exceptions;
using University.Core.Validations;
using Microsoft.Extensions.Logging;

namespace University.Core.Services
{
    public class CourseService : ICourseService
    {
        public readonly ICourseRepository _courseRepository;
        public readonly ILogger<CourseService> _logger;

        public CourseService(ICourseRepository courseRepository, ILogger<CourseService> logger)
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }

        public void Create(CreateCourseForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            var validation = FormValidator.Validate(form);

            if (!validation.IsValid)
                throw new BusinessException(validation.Errors);


            var course = new Course()
            {
                CourseName = form.CourseName,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
            };

            _courseRepository.Create(course);
            _courseRepository.SaveChanges();
        }

        public void Delete(int courseId)
        {
            var course = _courseRepository.GetById(courseId);

            if (course == null)
            {
                throw new NotFoundException("Course not found");
            }
            _courseRepository.Delete(course);
            _courseRepository.SaveChanges();
        }

        public List<CourseDTO> GetAll()
        {
            var allcourses = _courseRepository.GetAll();

            var dtos = allcourses.Select(course => new CourseDTO()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                StartDate = course.StartDate,
                EndDate = course.EndDate
            }).ToList();

            return dtos;
        }

        public CourseDTO GetById(int courseId)
        {
            _logger.LogInformation($"Somebody tried to call GetById {courseId}");
            var course = _courseRepository.GetById(courseId);

            if (course == null)
            {
                throw new NotFoundException("Course not found");
            }
            var dto = new CourseDTO()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                StartDate = course.StartDate,
                EndDate = course.EndDate
            };

            return dto;
        }

        public void Update(int CourseId, UpdateCourseForm form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            var validation = FormValidator.Validate(form);
            if (!validation.IsValid)
                throw new BusinessException(validation.Errors);

            var course = _courseRepository.GetById(CourseId);

            if (course == null)
            {
                throw new NotFoundException("Course not found");
            }

            course.CourseName = form.CourseName;
            course.StartDate = form.StartDate;
            course.EndDate = form.EndDate;

            _courseRepository.Update(course);
            _courseRepository.SaveChanges();

        }
    }

    public interface ICourseService
    {
        CourseDTO GetById(int courseId);
        List<CourseDTO> GetAll();

        void Create(CreateCourseForm form);
        void Update(int CourseId, UpdateCourseForm form);
        void Delete(int courseId);

    }
}
