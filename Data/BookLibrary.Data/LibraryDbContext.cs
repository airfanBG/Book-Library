using BookLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BookLibrary.Data
{
    public class LibraryDbContext: IdentityDbContext<User,Role,string>
    {
        private IConfigurationRoot Configuration { get; set; }
        public LibraryDbContext()
        {

        }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBooks> AuthorBooks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserBooks> UserBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("configuration.json").Build();
            optionsBuilder.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var user1 = new User()
            {
                FirstName = "XXXX",
                LastName = "XXXX",
                Email = "xxxx@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "Owner",
                NormalizedUserName = "OWNER",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Id="1"
                
            };
            builder.Entity<User>().HasData(user1);
            builder.Entity<Role>().HasData(new Role() { Name = "Admin" }, new Role() { Name = "User" }, new Role() { Name = "EMployee" });
            builder.Entity<Employee>().HasData(new Employee() {EmployeeNumber="111" });
            builder.Entity<Author>().HasData(new Author() { Name = "Test", Biography = "Test" }, new Author() { Name = "Test", Biography = "Test1" }, new Author() { Name = "Test2", Biography = "Test" });
            builder.Entity<Book>().HasData(new Book() { BookName = "Book1", BookPages = 100, BookAnnotation = "Book1" },new Book() { BookName = "Book2", BookPages = 100, BookAnnotation = "Book2" },new Book() { BookName = "Book3", BookPages = 100, BookAnnotation = "Book3" });
            builder.Entity<Department>().HasData(new Department() { DepartmentName = "Department1" });

            base.OnModelCreating(builder);
        }
    }
}
