

using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<CourseStoredDbContext>();
optionBuilder.UseSqlServer("Server=.; Database= CourseShopDb; User Id=sa; Password=0910173532; Encrypt=False");

using CourseStoredDbContext ctx = new CourseStoredDbContext(optionBuilder.Options);

var course = ctx.Courses.FirstOrDefault();