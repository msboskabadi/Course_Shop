using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime StartDateTime { get; set; }
        public ICollection<CourseTeachers> CourseTeachers { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Dicount> Dicounts { get; set; }
    }

    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CourseTeachers> CourseTeachers { get; set; }
    }

    public class CourseTeachers
    {
        public int CourseTeacherId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }

    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public ICollection<Course> courses { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string CommentBy { get; set; }
        public string CommentText { get; set; }
        public int StartCount { get; set; }
        public bool IsApprove { get; set; }
    }

    public class Dicount
    {
        public int DiscountId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Name { get; set; }
        public int NewPrice { get; set; }
    }
}
