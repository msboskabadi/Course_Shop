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
            var result = _courseStoreDbContext.Courses.Include(c => c.CourseTeachers).ThenInclude(c => c.Teacher).ToList();  
            foreach(var course in result)
            {
                Console.WriteLine($"Course : {course.Name}");

                foreach(var item in course.CourseTeachers)
                {
                    Console.WriteLine($"\t\t {item.Teacher.FirstName}");
                }
            }
        }
    }
}
