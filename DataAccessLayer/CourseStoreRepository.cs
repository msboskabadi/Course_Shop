using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CourseStoreRepository
    {
        private CourseStoredDbContext _courseStoreDbContext;

        public CourseStoreRepository(CourseStoredDbContext courseStoredDbContext)
        {
            _courseStoreDbContext = courseStoredDbContext;
        }

        public void PrintCourseAndTeacher()
        {
            var result = _courseStoreDbContext.Courses
                .Include(c => c.CourseTeachers.OrderByDescending(c => c.SortOrder)).ThenInclude(c => c.Teacher)
                .Include(c => c.Tags)
                .ToList();  
            foreach(var course in result)
            {
                Console.WriteLine($"Course : {course.Name}");

                foreach(var item in course.CourseTeachers)
                {
                    Console.WriteLine($"\t\t {item.Teacher.FirstName}");
                }

                foreach(var item in course.Tags)
                {
                    Console.WriteLine($"Tags : {item.Name}");
                }
            }
        }

        public void PrintCourseAndTeacherExplicit()
        {
            Console.WriteLine("".PadLeft(100, '*'));
            var result = _courseStoreDbContext.Courses.ToList();
            foreach (var course in result)
            {
                Console.WriteLine($"Course: {course.Name}");
                if (true)
                {
                    _courseStoreDbContext.Entry(course).Collection(c => c.CourseTeachers).Load();

                    foreach (var courseTeacher in course.CourseTeachers)
                    {
                        _courseStoreDbContext.Entry(courseTeacher).Reference(c => c.Teacher).Load();
                        Console.WriteLine($"\t\t {courseTeacher.Teacher.FirstName}, {courseTeacher.Teacher.LastName}");
                    }
                }
            }
            Console.WriteLine("".PadLeft(100, '*'));
        }
    }
}
