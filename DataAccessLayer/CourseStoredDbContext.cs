using CourseShop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CourseStoredDbContext:DbContext
    {
        #region Dbset
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseTeachers> CourseTeachers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; } 
        #endregion

        #region Constructor
        public CourseStoredDbContext(DbContextOptions<CourseStoredDbContext> options) : base(options)
        {
        }
        #endregion

        #region Method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        } 
        #endregion
    }
}
