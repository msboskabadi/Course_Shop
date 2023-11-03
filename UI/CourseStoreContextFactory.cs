using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class CourseStoreContextFactory : IDesignTimeDbContextFactory<CourseStoredDbContext>
    {
        public CourseStoredDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<CourseStoredDbContext>();
            optionBuilder.UseSqlServer("Server=.; Database= CourseShopDb; User Id=sa; Password=0910173532; Encrypt=False");

            CourseStoredDbContext ctx = new CourseStoredDbContext(optionBuilder.Options);

            return ctx;
        }
    }
}
