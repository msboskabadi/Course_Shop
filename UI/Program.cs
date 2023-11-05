

using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<CourseStoredDbContext>();
optionBuilder.UseSqlServer("Server=.; Database= CourseShopEntities; User Id=sa; Password=0910173532; Encrypt=False");
optionBuilder.LogTo(Console.WriteLine);
using CourseStoredDbContext ctx = new CourseStoredDbContext(optionBuilder.Options);

CourseStoreRepository repository = new CourseStoreRepository(ctx);
repository.PrintCourseAndTeacherExplicit();

Console.ReadKey();